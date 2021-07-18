using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Controllers
{
    public class CastsController : Controller
    {
        private readonly IMovieService _movieService;

        public CastsController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public async Task<IActionResult> CastDetails(int id)
        {
            var movie = await _movieService.GetCastMovieDetails(id);
            return View(movie);
        }  
          
        public async Task<IActionResult> GetMovieByCastId(int id)
        {
            var movie = await _movieService.GetCastMovieDetails(id);
            return View(movie);
        }
    }
}
