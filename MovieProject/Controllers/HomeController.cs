using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using Infrastructure.Repositories;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Data;

namespace MovieProject.Controllers
{
    public class HomeController : Controller
    {
        //Each and every request in MVC controller
        // localhost/home/index

       /* private readonly ILogger<HomeController> _logger;*/
        private readonly IMovieService _movieService;
        /*    public HomeController(ILogger<HomeController> logger)
            {
                _logger = logger;

            }*/
        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }

    
        public async Task< IActionResult> Index()
        {
            var movies = await _movieService.GetTopRevenueMovies();
            var myType = movies.GetType();
    
            /*
             * 3 ways to send the data from Controller/action to View
             * 1. *** Models (strongly typed models)
             * 2. ViewBag
             * 3. ViewData
             */
            ViewBag.MoviesCount = movies.Count();
            return View(movies);
        }

        public async Task<IActionResult>  Privacy()
        {           
            return View();
        }
   /*     [HttpGet]
        public IActionResult GetALLMovies()
        {
            var movieRepository = new MovieRepository();
            var movies = movieRepository.GetALLMovies();

            ViewBag.MoviesCount = movies.Count();
            return View(movies);
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
