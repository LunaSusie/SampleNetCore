using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerMvc.Controllers
{
    [Authorize]
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}