using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Core.Entities;
using Blog.Core.Interface;
using Blog.Infrastructure.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Blog.Host.Controllers
{
    [Route("api/[Controller]")]
    public class PostController : Controller
    {
        private readonly IRepository<Post> _postRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<PostController> _logger;
 
        public PostController(IRepository<Post> postRepository, IUnitOfWork unitOfWork, IMapper mapper, ILogger<PostController> logger)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }


        // GET
        public async Task<IActionResult> Index()
        {
            var posts=await _postRepository.GetAllAsync();
            var postsResource = _mapper.Map<IEnumerable<Post>, IEnumerable<PostResource>>(posts);
            _logger.LogError("all posts...");
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