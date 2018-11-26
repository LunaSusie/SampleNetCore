using AutoMapper;
using Blog.Core.Entities;
using Blog.Infrastructure.Resources;

namespace Blog.Host.Extensions
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostResource>();
            CreateMap<PostResource, Post>();
        }
    }
}