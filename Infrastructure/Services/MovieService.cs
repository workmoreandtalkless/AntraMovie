using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;

using System.Data.SqlClient;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task<List<APIMovieCardResponseModel>> GetTopRevenueMoviesAPI()
        {
            var movies = await _movieRepository.GetHighest30GrossingMovies();

            var movieCards = new List<APIMovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(
                    new APIMovieCardResponseModel
                    {
                        Id = movie.Id,
                        Budget = movie.Budget.GetValueOrDefault(),
                        Title = movie.Title,
                        PosterUrl = movie.PosterUrl
                    }
                    );

            }
            return movieCards;
        }
        public async Task<List<MovieCardResponseModel>> GetTopRevenueMovies()
        {
            var movies = await _movieRepository.GetHighest30GrossingMovies();

            var movieCards = new List<MovieCardResponseModel>();
            foreach(var movie in movies)
            {
                movieCards.Add(
                    new MovieCardResponseModel 
                    { Id = movie.Id, 
                        Budget = movie.Budget.GetValueOrDefault(), 
                        Title = movie.Title, 
                        PosterUrl = movie.PosterUrl 
                    }
                    );

            }
            return movieCards;
        }

        public async Task<MovieCardResponseModel> GetMostRevenueMovies()
        {
            var movie = await _movieRepository.GetHighestGrossingMovies();
            var movieCard = new MovieCardResponseModel
            {
                Id = movie.Id, 
                Budget = movie.Budget.GetValueOrDefault(), 
                Title = movie.Title, 
                PosterUrl = movie.PosterUrl 
            };
            return movieCard;
        }

        public async Task<MovieDetailsResponseModel> GetMovieDetails(int Id)
        {
            var movie = await _movieRepository.GetByIdAsync(Id);
            var movieDetails = new MovieDetailsResponseModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                PosterUrl = movie.PosterUrl,
                BackdropUrl = movie.BackdropUrl,
                Rating = movie.Rating,
                Overview = movie.Overview,
                Tagline = movie.Tagline,
                Budget = movie.Budget,
                Revenue = movie.Revenue,
                ImdbUrl = movie.ImdbUrl,
                TmdbUrl = movie.TmdbUrl,
                ReleaseDate = movie.ReleaseDate,
                RunTime = movie.RunTime,
                Price = movie.Price,
            };

            movieDetails.Casts = new List<CastResponseModel>();
           /* movieDetails.FavoritesCount = movie.Favorites.Count();*/

            foreach (var cast in movie.MovieCasts)
            {

                movieDetails.Casts.Add(new CastResponseModel()
                {
                    Id = cast.CastId,
                    Name = cast.Cast.Name,
                    Gender = cast.Cast.Gender,
                    TmdbUrl = cast.Cast.TmdbUrl,
                    ProfilePath = cast.Cast.ProfilePath,
                    Character = cast.Character,

                });
            }

            movieDetails.Genres = new List<GenreModel>();
            foreach(var genre in movie.MovieGenres)
            {
                movieDetails.Genres.Add(new GenreModel()
                {
                    Id = genre.Genre.ID,
                    Name = genre.Genre.Name,
                }) ;
            }
            return movieDetails;
        }

        public async Task<List<MovieCardResponseModel>> GetGenreMovieDetails(int Id)
        {
            var movies = await _movieRepository.GetMovieByGenreId(Id);

            var movieCards = new List<MovieCardResponseModel>();
            

            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Budget = movie.Budget.GetValueOrDefault(),
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl,

                });

            }
       
            return movieCards;

        }

        public async Task<List<MovieCardResponseModel>> GetCardMovieDetails(int Id)
        {
            var movies = await _movieRepository.GetMovieByCastId(Id);
            var movieCards = new List<MovieCardResponseModel>();


            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Budget = movie.Budget.GetValueOrDefault(),
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl,

                });
            }

            return movieCards;
        }





        public Task<List<MovieCastResponseModel>> GetCastMovieDetails(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MovieCardResponseModel>> GetTopRatedMovies()
        {
            var movies = await _movieRepository.GetTopRatedMovie();
            var moviecard = new List<MovieCardResponseModel>();
            foreach(var movie in movies)
            {
                moviecard.Add(new MovieCardResponseModel
                {

                    Id = movie.Id,
                    Budget = movie.Budget.GetValueOrDefault(),
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl,
                });

            };
            return moviecard;
        }

        
    }
}
