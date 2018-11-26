using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Core.Entities;
using Blog.Core.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Blog.Infrastructure.DataBase;
using Blog.Infrastructure.Repository;
using Blog.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Blog.Host.Extensions;
using Blog.Infrastructure.Resources;
using FluentValidation;

namespace Blog.Host
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
          
        }
    }
    /// <summary>
    /// 开发环境
    /// </summary>
    public class StartupDevelopment
    {
        private readonly IConfiguration Configuration;

        public StartupDevelopment(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //注入mvc
            services.AddMvc();

            services.AddDbContext<BlogDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });


            //http重定向https配置
            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                options.HttpsPort = 5001;
            });

            //官方建议的生产https方式
            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
                options.ExcludedHosts.Add("example.com");
                options.ExcludedHosts.Add("www.example.com");
            });
            //Repository注入
            services.AddScoped<IRepository<Post>, PostRepository>();
            //UnitOfWork注入
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //AutoMapper注入
            services.AddAutoMapper();
            //FluentValidation注入
            services.AddTransient<IValidator<PostResource>, PostResourceValidator>();
        }

       
        public void Configure(IApplicationBuilder app,ILoggerFactory loggerFactory)
        {
            //异常页面
            //app.UseDeveloperExceptionPage();
            
            //全局异常处理
            app.UseBlogExceptionHandler(loggerFactory);

            //官方建议的生产https方式
            app.UseHsts();

            //https重定向中间件
            app.UseHttpsRedirection();

            //mvc中间件
            app.UseMvc();
        }
    }
    /// <summary>
    /// 生产环境
    /// </summary>
    public class StartupProduction
    {
        public void ConfigureServices(IServiceCollection services)
        {
            
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           
        }
    }
}
