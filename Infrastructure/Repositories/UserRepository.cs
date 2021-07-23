using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<User>> GetAllUserAPI()
        {
            var user = await _dbContext.Users.Take(30).ToListAsync();

            return user;
        }

        public async Task<User> GetUserByEmail(string email)
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
                return user;
            }

            
    }
}
