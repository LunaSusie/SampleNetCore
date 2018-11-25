using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

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
        public void ConfigureServices(IServiceCollection services)
        {
            //注入mvc
            services.AddMvc();

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
        }

       
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //异常页面
            app.UseDeveloperExceptionPage();

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
