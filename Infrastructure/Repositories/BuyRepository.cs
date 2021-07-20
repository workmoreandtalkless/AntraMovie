using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BuyRepository : EfRepository<Purchase>, IBuyRepository
    {

        public BuyRepository(MovieShopDbContext dbContext) : base(dbContext)
        {

        }


        public async override Task<IEnumerable<Purchase>> ListAsync(Expression<Func<Purchase,bool>> filer)
        {
            var purchases = _dbContext.Purchases.Where(filer).ToListAsync();

            if (purchases == null)
            {
                throw new Exception("without Movie to buy");
            }
            return purchases;
        }

        public override async Task<Movie> GetByIdAsync(int Id)
        {
            var movie = await _dbContext.Movies.Include(m => m.MovieCasts).ThenInclude(m => m.Cast)
                .Include(m => m.MovieGenres).ThenInclude(m => m.Genre).FirstOrDefaultAsync(m => m.Id == Id);

            if (movie == null)
            {
                throw new Exception("No Movie Found with {Id}");
            }

            var movieRating = await _dbContext.Reviews.Where(m => m.MovieId == Id).AverageAsync(m => m.Rating == null ? 0 : m.Rating);

            if (movieRating > 0)
            {
                movie.Rating = movieRating;
            }

            return movie;

        }
    }
}
