using System.Threading.Tasks;
using Blog.Infrastructure.DataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Host.Controllers
{
    [Route("api/[Controller]")]
    public class PostController : Controller
    {
        private readonly BlogDbContext _blogDbContext;

        public PostController(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            var posts=await _blogDbContext.Posts.ToListAsync();
            return Ok(posts);
        }
    }
}