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
        
        public Task<List<MovieCardResponseModel>> GetCardMovieDetails(int Id);
        public Task<List<MovieCastResponseModel>> GetCastMovieDetails(int Id);
        
        // below for ApI
        public  Task<MovieCardResponseModel> GetTopRatedMovies();
       
    }
}
