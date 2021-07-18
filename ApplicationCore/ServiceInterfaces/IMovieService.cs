using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;
namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
      public  Task<List<MovieCardResponseModel>>GetTopRevenueMovies();

      public Task<MovieCardResponseModel> GetMostRevenueMovies();

        public Task<MovieDetailsResponseModel> GetMovieDetails(int Id);

        public Task<List<MovieCardResponseModel>> GetGenreMovieDetails(int Id);
        public Task<List<MovieCardResponseModel>> GetCastMovieDetails(int Id);
        //10 methods
        /*        public List<MovieCardResponseModel> GetALLMovies();
                public MovieCardResponseModel GetMovieById();
                public MovieCardResponseModel GetTopRatedMovie();
                public MovieCardResponseModel GetTopRevenueMovie();
                public MovieCardResponseModel GetGenreById();
                public MovieCardResponseModel GetReviewById();*/
    }
}
