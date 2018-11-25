using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthJwtInAPI.CustomTokenValidator;
using AuthJwtInAPI.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AuthJwtInAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //配置jwt
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));
            var jetSettings = new JwtSettings();
            Configuration.Bind("JwtSettings", jetSettings);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = jetSettings.Issuer,
                    ValidAudience = jetSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jetSettings.SecretKey))
                };

                //自定义jwt
                //1.清空默认的验证,添加自定义验证
//                options.SecurityTokenValidators.Clear();
//                options.SecurityTokenValidators.Add(new MyTokenValidator());
//                //2.设定OnMessageReceived事件
//                options.Events = new JwtBearerEvents()
//                {
//                    OnMessageReceived = context =>
//                    {
//                        var token = context.Request.Headers["MyToken"];
//                        context.Token = token.FirstOrDefault();
//                        return Task.CompletedTask;
//                    }
//                };

            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
