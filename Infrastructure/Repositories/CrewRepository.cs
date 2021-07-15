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
    public class CrewRepository : EfRepository<Crew>, ICrewRepository
    {
        public CrewRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }
    }
}
