using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcDemo.Models;
using MvcDemo.Service;

namespace MvcDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICinemaService _cinemaService;

        public HomeController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "电影院";
            return View();
        }

        public async Task<IActionResult> Add(Cinema model)
        {
            if (ModelState.IsValid)
            {
                await _cinemaService.AddAsync(model);
            }

            return RedirectToAction("Index");
        }
    }
}