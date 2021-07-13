using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Repositories;
namespace MovieProject.Controllers
{
    public class HomeController : Controller
    {
        //Each and every request in MVC controller
        // localhost/home/index

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
         }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetALLMovies()
        {
            var movieRepository = new MovieRepository();
            var movies = movieRepository.GetALLMovies();

            ViewBag.MoviesCount = movies.Count();
            return View(movies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
