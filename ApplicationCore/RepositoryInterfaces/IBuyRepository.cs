using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IBuyRepository : IAsyncRepository<Purchase>
    {
        Task<IEnumerable<Purchase>> GetAll();
        Task<IEnumerable<Purchase>> GetPurchasesByuserId(int uId);
        Task<bool> CheckMoviePurchaseForUser(int userId, int movieId);

        Task<Purchase> GetById(int userId, int movieId);
    }
}
