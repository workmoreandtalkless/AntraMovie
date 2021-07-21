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

        public Task<List<Movie>> GetMovieByGenreId(int Id);

        public Task<Movie> GetHighestGrossingMovies();

        public Task<List<Movie>> GetMovieByCastId(int Id);
       
        // for api
        public Task<Movie> GetTopRatedMovie();


    }
}
