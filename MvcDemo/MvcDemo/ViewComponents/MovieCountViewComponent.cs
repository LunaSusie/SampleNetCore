using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcDemo.Models;
using MvcDemo.Service;

namespace MvcDemo.ViewComponents
{
    public class MovieCountViewComponent : ViewComponent
    {
        private readonly IMovieService _movieService;

        public MovieCountViewComponent(IMovieService movieService)
        {
            _movieService = movieService;
        }


        public async Task<IViewComponentResult> InvokeAsync(int cinemaId)
        {
            var cinemas = await _movieService.GetByCinemaAsync(cinemaId);
            var count = cinemas.Count();
            return View(count);
        }
       
    }
}