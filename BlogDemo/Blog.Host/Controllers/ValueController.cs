using Microsoft.AspNetCore.Mvc;

namespace Blog.Host.Controllers
{
    [Route("api/[Controller]")]
    public class ValueController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return Ok("hello");
        }
    }
}