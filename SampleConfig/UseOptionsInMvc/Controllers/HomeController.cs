using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OptionsBindConfig;

namespace UseOptionsInMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly Class _myClass;

        public HomeController(IOptions<Class> myClass)
        {
            _myClass = myClass.Value;
        }
        // GET
        public IActionResult Index()
        {
            return View(_myClass);
        }
    }
}