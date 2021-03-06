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
    public class ReviewRepository : EfRepository<Review>, IReviewRepository
    {
        public ReviewRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Review> GetReviewById(int uid, int mid)
        {
            var review = await _dbContext.Reviews.Where(r =>r.UserId==uid && r.MovieId == mid).FirstOrDefaultAsync();

            return review;
        }

        public async Task<IEnumerable<Review>> GetReviewByMovieId(int mid)
        {
            //var reviews = await _dbContext.Reviews.Where(r => r.MovieId == mid).ToList();
            var reviews = await _dbContext.Reviews.Where(r => r.MovieId == mid).ToListAsync();

            return reviews;
        }

        public async Task<IEnumerable<Review>> GetReviewByUserId(int uid)
        {
            var reviews = await _dbContext.Reviews.Where(r => r.UserId == uid).ToListAsync();
            return reviews;
        }
    }
}
