using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> CreateMovie()
        {
            return View();
        }

    }
}
