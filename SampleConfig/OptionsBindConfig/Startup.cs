using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OptionsBindConfig
{
    public class Startup
    {

        public IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
          
            app.Run(async (context) =>
            {
                var myClass = new Class();
                Configuration.Bind(myClass);
                await context.Response.WriteAsync($"ClassNo:{myClass.ClassNO}\n");
                await context.Response.WriteAsync($"ClassDesc:{myClass.ClassDesc}\n");
                await context.Response.WriteAsync($"StudentCount:{myClass.Students.Count}\n");
            });
        }
    }
}
