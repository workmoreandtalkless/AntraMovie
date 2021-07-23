using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenreRepository : EfRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

  

        public override async Task<IEnumerable<Genre>> ListAllAsync()
        {


            var genres = await _dbContext.Genres.Include(g => g.movieGenres).ThenInclude(g => g.Movie).ToListAsync();
            /*.Include(g => g.movieGenres).ThenInclude(mg => mg.Movie)
             .OrderBy(g => g.Name)*/
            return genres;
        }

        public async Task<List<Movie>> GetHighest30GrossingMovies()
        {
            var topMovies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return topMovies;

            
        }
        /*   public virtual async Task<IEnumerable<Genre>> ListAllAsync()
           {
               return await _dbContext.Set<Genre>().ToListAsync();
           }*/
    }
}
