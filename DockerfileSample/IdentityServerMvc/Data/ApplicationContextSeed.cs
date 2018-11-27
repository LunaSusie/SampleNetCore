

using System;
using System.Linq;
using System.Threading.Tasks;
using IdentityServerMvc.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IdentityServerMvc.Data
{
    public class ApplicationContextSeed
    {
        public static async Task SeedAsync(IApplicationBuilder appbuild, ILoggerFactory loggerFactory, int? retry = 0)
        {
            var retryForAvaiability = retry.Value;
            {
                try
                {
                    using (var scope = appbuild.ApplicationServices.CreateScope())
                    {
                        var context =
                            (ApplicationDbContext) scope.ServiceProvider.GetService(typeof(ApplicationDbContext));
                        var logger =
                            (ILogger<ApplicationContextSeed>) scope.ServiceProvider.GetService(
                                typeof(ILogger<ApplicationContextSeed>));
                        logger.LogDebug("开始初始化数据库");
                        context.Database.Migrate();
                        if (!context.Users.Any())
                        {
                            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                            var defaultUser = new User
                            {
                                UserName = "Luna@qq.com",
                                Email = "Luna@qq.com",
                                NormalizedEmail = "Luna@qq.com",
                                NormalizedUserName = "admin"
                            };
                            var result = await userManager.CreateAsync(defaultUser, "pwd123456");
                            if (!result.Succeeded) { throw new Exception("初始化数据库失败"); }
                            else { logger.LogDebug("初始化数据库成功"); }
                        }
                    }
                }
                catch (Exception e)
                {
                    retryForAvaiability++;
                    if (retryForAvaiability < 10)
                    {
                       await SeedAsync(appbuild, loggerFactory, retryForAvaiability);
                    }
                        var logger = loggerFactory.CreateLogger(typeof(ApplicationDbContext));
                    logger.LogError(e.Message+$" times:{retryForAvaiability}");
                }
            }
        }
    }
}