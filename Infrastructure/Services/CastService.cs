using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;
       /* private readonly IMovieRepository _movieRepository;*/
        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        } 
/*        public CastService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }*/

        public async Task<MovieCastResponseModel> GetCastMovieDetails(int Id)
        {
            var cast = await _castRepository.GetCastByIdAsync(Id);
            var MovieCast = new MovieCastResponseModel()
            {
                Id = cast.Id,
                Name = cast.Name,
                Gender = cast.Gender == "2" ? "male" : "female",
                MyProperty = cast.MyProperty,
                TmdbUrl = cast.TmdbUrl,
                ProfilePath = cast.ProfilePath
            };

            MovieCast.MovieCards = new List<MovieCardResponseModel>();

            foreach (var movie in cast.MovieCasts)
            {
                MovieCast.MovieCards.Add(
                       new MovieCardResponseModel
                       {
                           Id = movie.MovieId,
                           Title = movie.Movie.Title,
                           PosterUrl = movie.Movie.PosterUrl,
                           Budget = movie.Movie.Budget.GetValueOrDefault()

                       });
            };
           
            return MovieCast;
          }


    }
    
}

/*
             public int Id { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public decimal Budget { get; set; }
    
        public int MovieId { get; set; }
        public int CastId { get; set; }
        public string Character { get; set; }

        public List<MovieCardResponseModel> MovieCards { get; set; }
 */