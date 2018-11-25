using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcDemo.Models;
using MvcDemo.Service;

namespace MvcDemo.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICinemaService _cinemaService;

        public MovieController(ICinemaService cinemaService, IMovieService movieService)
        {
            _cinemaService = cinemaService;
            _movieService = movieService;
        }


        // GET
        public async Task<IActionResult> Index(int cinemaId)
        {
            var cinema = await _cinemaService.GetByIdAsync(cinemaId);
            ViewBag.Title= cinema.Name;
            ViewBag.cinemaId = cinemaId;
            return View(await _movieService.GetByCinemaAsync(cinemaId));
        }
        public IActionResult Add(int cinemaId)
        {
            ViewBag.Title = "添加电影";
            return View(new Movie {CinemaId = cinemaId});

        }
        [HttpPost]
        public async Task<IActionResult> Add(Movie model)
        {
            if (ModelState.IsValid)
            {
                await _movieService.AddAsync(model);
            }

            return RedirectToAction("Index",new {cinemaId=model.Id});
        }
    }
}