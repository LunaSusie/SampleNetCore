using System;
using System.Threading.Tasks;
using Blog.Core.Entities;
using Blog.Core.Interface;
using Blog.Infrastructure.DataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Host.Controllers
{
    [Route("api/[Controller]")]
    public class PostController : Controller
    {
        private readonly IRepository<Post> _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostController(IRepository<Post> postRepository, IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }


        // GET
        public async Task<IActionResult> Index()
        {
            var posts=await _postRepository.GetAllAsync();
            return Ok(posts);
        }
        [HttpPost]
        public async Task<IActionResult> Post()
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