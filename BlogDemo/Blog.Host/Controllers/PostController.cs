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

        public PostController(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }


        // GET
        public async Task<IActionResult> Index()
        {
            var posts=await _postRepository.GetAllAsync();
            return Ok(posts);
        }
    }
}