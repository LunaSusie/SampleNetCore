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

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "电影院";
            return View(await _cinemaService.GetAllAsync());
        }
        [HttpGet]
        public  IActionResult Create()
        {
            ViewBag.Title = "新增电影院";
            return View(new Cinema());
        }
        [HttpPost]
        public async Task<IActionResult> Create(Cinema model)
        {
            if (ModelState.IsValid)
            {
                await _cinemaService.AddAsync(model);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int cinemaId)
        {
            ViewBag.Title = "修改影院信息";
            var cinema = await _cinemaService.GetByIdAsync(cinemaId);
            return View(cinema);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int cinemaId,Cinema model)
        {
            if (ModelState.IsValid)
            {
                var exist = await _cinemaService.GetByIdAsync(cinemaId);
                if (exist == null)
                {
                    return NotFound();
                }
                else
                {

                    exist.Name = model.Name;
                    exist.Location = model.Location;
                    exist.Capacity = model.Capacity;
                }
            }
            return RedirectToAction("Index");
        }
    }
}