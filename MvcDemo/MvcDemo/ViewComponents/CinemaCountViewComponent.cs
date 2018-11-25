using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcDemo.Models;
using MvcDemo.Service;

namespace MvcDemo.ViewComponents
{
    public class CinemaCountViewComponent : ViewComponent
    {
        private readonly ICinemaService _cinemaService;

        public CinemaCountViewComponent(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cinemas = await _cinemaService.GetAllAsync();
            var count = cinemas.Count();
            return View(count);
        }
       
    }
}