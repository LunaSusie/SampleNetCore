using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Core.Entities;
using Blog.Core.Interface;
using Blog.Infrastructure.DataBase;
using Blog.Infrastructure.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Host.Controllers
{
    [Route("api/[Controller]")]
    public class PostController : Controller
    {
        private readonly IRepository<Post> _postRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
 
        public PostController(IRepository<Post> postRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        // GET
        public async Task<IActionResult> Index()
        {
            var posts=await _postRepository.GetAllAsync();
            var postsResource = _mapper.Map<IEnumerable<Post>, IEnumerable<PostResource>>(posts);
            return Ok(postsResource);
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var post = new Post
            {
                Author = "admin", Title = "admin title", Body = "admin body", CreateTime = DateTime.Now,
                LastModifyTime = DateTime.Now
            };
            _postRepository.Create(post);
            await _unitOfWork.SaveAsync();
            return Ok();
        }
    }
}