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
       
        public MovieService()
        {

        }
        public List<MovieCardResponseModel> GetALLMovies()
        {
            throw new NotImplementedException();
        }

        public MovieCardResponseModel GetGenreById()
        {
            throw new NotImplementedException();
        }

        public MovieCardResponseModel GetMovieById()
        {
            throw new NotImplementedException();
        }

        public MovieCardResponseModel GetReviewById()
        {
            throw new NotImplementedException();
        }

        public MovieCardResponseModel GetTopRatedMovie()
        {
            throw new NotImplementedException();
        }

        public MovieCardResponseModel GetTopRevenueMovie()
        {
            throw new NotImplementedException();
        }

        public List<MovieCardResponseModel> GetTopRevenueMovies()
        {
            throw new NotImplementedException();
        }
    }
}
