using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using MvcDemo.Service;
using MvcDemo.Service.MemoryService;

namespace MvcDemo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //注入mvc
            services.AddMvc();
            //注入services
            services.AddSingleton<ICinemaService, CinemaService>();
            services.AddSingleton<IMovieService, MovieService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //静态页面
            app.UseStaticFiles();
            //使用状态码页面
            app.UseStatusCodePages();
            app.UseMvc(routes => { routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}"); });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
    public class StartupDevelopment
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //注入mvc
            services.AddMvc();
            //注入services
            services.AddSingleton<ICinemaService, CinemaService>();
            services.AddSingleton<IMovieService, MovieService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //反向代理ForwardedHeaders
            // if (env.IsProduction())
            // {
            //       app.UseForwardedHeaders(new ForwardedHeadersOptions
            //    {
            //     ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedFor
            //  });
            // }

            //静态页面
            app.UseStaticFiles();
            //使用状态码页面
            app.UseStatusCodePages();
            app.UseMvc(routes => { routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}"); });
        }
    }
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
