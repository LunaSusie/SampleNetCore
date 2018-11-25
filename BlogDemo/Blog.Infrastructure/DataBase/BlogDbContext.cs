using System;
using System.Collections.Generic;
using System.Text;
using Blog.Core.Entities;
using Blog.Infrastructure.DataBase.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.DataBase
{
    public class BlogDbContext:DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PostConfiguration());
        }
        public DbSet<Post> Posts { get; set; }
    }
}
