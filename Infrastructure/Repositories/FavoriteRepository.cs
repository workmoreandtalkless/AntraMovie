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
    public class FavoriteRepository : EfRepository<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Favorite> FindFavorite(int id, int MovieId)
        {
            var favoriteEntity = await _dbContext.Favorites.Where(f => f.UserId == id && f.MovieId == MovieId).FirstOrDefaultAsync();
            
            
            return favoriteEntity;
        }

        public async Task<List<Favorite>> GetFavoriteByUserId(int uid)
        {
            var favorites = await _dbContext.Favorites.Where(f => f.UserId == uid).ToListAsync();

            return favorites;

        }
    }
}
