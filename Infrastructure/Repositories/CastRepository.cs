using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CastRepository : EfRepository<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDbContext dbContext) : base(dbContext)
        {

       
        }
        public override async Task<Cast> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Set<Cast>().FindAsync(id);
            return entity;
        }
    }
}
