using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
namespace ApplicationCore.RepositoryInterfaces
{
    public interface IMovieRepository: IAsyncRepository<Movie>
    {
       public  Task<List<Movie>> GetHighest30GrossingMovies();

       public Task<Movie> GetHighestGrossingMovies();
/*        //10 methods
        public List<Movie> GetALLMovies();
        public Movie GetMovieById();
        public Movie GetTopRatedMovie();
        public Movie GetTopRevenueMovie();
        public Movie GetGenreById();
        public Movie GetReviewById();*/

    }
}
