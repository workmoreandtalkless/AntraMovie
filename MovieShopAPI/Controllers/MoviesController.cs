using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreService _genreRepository;
        public MoviesController(IMovieService movieService , IMovieRepository movieRepository)
        {
            _movieService = movieService;
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovie()
        {
            var movies = await _movieRepository.ListAllAsync();

            if (!movies.Any())
            {
                return NotFound("no movie found");
            }
            // in .Net Core 3.1 > System.Text.Json
            return Ok(movies);
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieDetails(id);
            if (movie == null)
            {
                return NotFound($"no movie found for that {id} ");
            }
            return Ok(movie);
        }

        [HttpGet]
        [Route("toprated")]
        public async Task<IActionResult> GetTopRatedMovies()
        {
            var movie = await _movieService.GetTopRatedMovies();

            if (movie==null)
            {
                return NotFound("no movie found");
            }
            // in .Net Core 3.1 > System.Text.Json
            return Ok(movie);
        } 


        [HttpGet]
        [Route("toprevenue")]
        public async Task<IActionResult> GetTopRevenueMovies()
        {
           var movies = await _movieService.GetTopRevenueMovies();

            if (!movies.Any())
            {
                return NotFound("no movie found");
            }
            // in .Net Core 3.1 > System.Text.Json
            return Ok(movies);
        }

        [HttpGet]
        [Route("genre/{genreId:int}")]
        public async Task<IActionResult> GetGenreByGenreId(int gid)
        {
            var genre = await _genreRepository.GetGenreByGenreId(gid);
            if (genre==null)
            {
                return NotFound("no movie found");
            }

            return Ok(genre);
        }
    }
}
