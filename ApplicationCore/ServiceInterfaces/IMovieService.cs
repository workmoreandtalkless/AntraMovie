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
      public  List<MovieCardResponseModel> GetTopRevenueMovies();
      
        //10 methods
        public List<MovieCardResponseModel> GetALLMovies();
        public MovieCardResponseModel GetMovieById();
        public MovieCardResponseModel GetTopRatedMovie();
        public MovieCardResponseModel GetTopRevenueMovie();
        public MovieCardResponseModel GetGenreById();
        public MovieCardResponseModel GetReviewById();
    }
}
