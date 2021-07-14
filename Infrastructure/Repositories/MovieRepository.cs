using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;

using System.Data.SqlClient;

namespace Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
      

        public List<Movie> GetALLMovies()
        {
            throw new NotImplementedException();
        }

        public Movie GetGenreById()
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetHighest30GrossingMovies()
        {
            throw new NotImplementedException();
        }

        public Movie GetMovieById()
        {
            throw new NotImplementedException();
        }

        public Movie GetReviewById()
        {
            throw new NotImplementedException();
        }

        public Movie GetTopRatedMovie()
        {
            throw new NotImplementedException();
        }

        public Movie GetTopRevenueMovie()
        {
            throw new NotImplementedException();
        }
    }
}
