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
        /*private readonly IMovieService _movieService;*/
        private readonly ICastService _castService;

      /*  public CastsController(IMovieService movieService)
        {
            _movieService = movieService;
        }*/
        public CastsController(ICastService castService)
        {
            _castService = castService;
        }
   /*     public async Task<IActionResult> CastDetails(int id)
        {
            var movie = await _movieService.GetCardMovieDetails(id);
            return View(movie);
        }  */
          
        public async Task<IActionResult> GetMovieByCastId(int id)
        {
            var movie = await _castService.GetCastMovieDetails(id);
            return View(movie);
        }
    }
}
