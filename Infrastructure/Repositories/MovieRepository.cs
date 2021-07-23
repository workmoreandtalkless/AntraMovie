using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Linq.Expressions;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
            
        }
        public async Task<List<Movie>> ListAllAsync()
        {
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).ToListAsync();
            return movies;
        }
        // who is calling this method?
        public async Task<List<Movie>> GetHighest30GrossingMovies()
        {
            var topMovies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return topMovies;
        }
        public override async Task<Movie> GetByIdAsync(int Id)
        {
            var movie = await _dbContext.Movies.Include(m => m.MovieCasts).ThenInclude(m => m.Cast)
                .Include(m => m.MovieGenres).ThenInclude(m => m.Genre).FirstOrDefaultAsync(m=>m.Id == Id);

            if(movie == null)
            {
                throw new Exception("No Movie Found with {Id}");
            }

            var movieRating = await _dbContext.Reviews.Where(m => m.MovieId == Id).AverageAsync(m=>m.Rating==null?0:m.Rating);

            if (movieRating > 0)
            {
                movie.Rating = movieRating;
            }

            return movie;
            
        }

        public async Task<Movie> GetHighestGrossingMovies()
        {
            var topMovies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).FirstAsync();
            return topMovies;
        }

        public async Task<List<Movie>> GetMovieByGenreId(int Id)
        {
            var movie = await _dbContext.MovieGenres.Where(m => m.GenreId == Id).Select(g => g.Movie).ToListAsync();
            return  movie;
        }

        public async Task<List<Movie>> GetMovieByCastId(int Id)
        {
            var movie = await _dbContext.MovieCasts.Where(m => m.CastId == Id).Select(g => g.Movie).ToListAsync();
            return movie;
        }

        // for api
        public async Task<List<Movie>> GetTopRatedMovie()
        {
            var movies = await _dbContext.Movies.Include(m => m.Reviews).OrderByDescending(m => m.Rating).Take(30).ToListAsync();
            
            // var movie = await movies.OrderByDescending(r => r.Rating);
            

            return movies;
        }
    }
}
