using System;
using System.Collections.Generic;
using System.Text;
using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.DataBase
{
    public class BlogDbContext:DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options):base(options)
        {
            
        }
        public DbSet<Post> Posts { get; set; }
    }
}
