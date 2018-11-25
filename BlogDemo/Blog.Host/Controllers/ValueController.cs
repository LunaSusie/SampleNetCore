using Microsoft.AspNetCore.Mvc;

namespace Blog.Host.Controllers
{
    public class ValueController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return Ok("hello");
        }
    }
}