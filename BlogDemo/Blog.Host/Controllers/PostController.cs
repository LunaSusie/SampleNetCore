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
    /// <summary>
    /// RestApi
    /// 内容协商输入：Content-Type,服务器接受类型，默认application/xml
    /// 内容协商输出：Accept，客户端接收类型
    /// 
    /// </summary>
    [Route("api/posts")]
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
        /// <summary>
        /// rest api 规范,集合数据为空，返回空数组即可
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts=await _postRepository.GetAllAsync();
            var postsResource = _mapper.Map<IEnumerable<Post>, IEnumerable<PostResource>>(posts);
            _logger.LogInformation("all posts...");
            return Ok(postsResource);
        }
        /// <summary>
        /// rest api 规范，单条数据有返回数据，没有返回404(not found)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            if (post == null) return NotFound();
            var postResource = _mapper.Map<Post, PostResource>(post);
            _logger.LogInformation("one posts...");
            return Ok(postResource);
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