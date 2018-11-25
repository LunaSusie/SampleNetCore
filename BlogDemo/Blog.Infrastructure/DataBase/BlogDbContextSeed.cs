using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;

namespace Blog.Infrastructure.DataBase
{
    public class BlogDbContextSeed
    {
        public static async Task SeedAsync(BlogDbContext blogDbContext,ILoggerFactory loggerFactory,int retry=0)
        {
            int retryForAvailability = retry;
            try
            {
                if (!blogDbContext.Posts.Any())
                {
                    blogDbContext.Posts.AddRange(
                        new List<Post>
                        {
                            new Post
                            {
                                Title = "post Title1",
                                Body = "body 1",
                                Author = "dave",
                                CreateTime = DateTime.Now,
                                LastModifyTime = DateTime.Now
                            },
                            new Post
                            {
                                Title = "post Title2",
                                Body = "body 2",
                                Author = "dave",
                                CreateTime = DateTime.Now,
                                LastModifyTime = DateTime.Now
                            },
                            new Post
                            {
                                Title = "post Title3",
                                Body = "body3",
                                Author = "dave",
                                CreateTime = DateTime.Now,
                                LastModifyTime = DateTime.Now
                            },
                            new Post
                            {
                                Title = "post Title3",
                                Body = "body4",
                                Author = "dave",
                                CreateTime = DateTime.Now,
                                LastModifyTime = DateTime.Now
                            },
                        }
                    );
                    await blogDbContext.SaveChangesAsync();
                }
            }
            catch(Exception e)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var logger = loggerFactory.CreateLogger<BlogDbContextSeed>();
                    logger.LogError(e.Message);
                    await SeedAsync(blogDbContext, loggerFactory, retryForAvailability);
                }
            }
        }
    }
}