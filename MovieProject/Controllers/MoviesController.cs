using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Models;


using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using ApplicationCore.Entities;
using Infrastructure.Repositories;

using Infrastructure.Data;
namespace MovieProject.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        // GET
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService.GetMovieDetails(id);
            return View(movie);
        }

        public async Task<IActionResult> GetMovieByGenreId(int id)
        {
            var movie = await _movieService.GetGenreMovieDetails(id);
            return View(movie);
        }
    }
}