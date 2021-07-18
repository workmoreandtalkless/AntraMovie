using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreService _genreService;
        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        /*public  PartialViewResult Index()
        {
            return PartialView("_MovieGenre", _genreService.GetAllGenres().Order
                OrderBy(g => g.Name).ToListAsync());
        }*/

        // GET
        public async Task<IActionResult> Genre()
        {
            var genre = await _genreService.GetAllGenres();
            return View(genre);

            // getMovieByGeneralId(int Id)
        }

        public PartialViewResult Index()
        {
            return PartialView("MovieGenre", _genreService.GetAllGenres());
        }


        // GET
        /*  public async Task<IActionResult> GetMovieByGenreId(int id)
          {
              var genreModel = await _genreService

                  return View(movie);
          }*/



    }
}
