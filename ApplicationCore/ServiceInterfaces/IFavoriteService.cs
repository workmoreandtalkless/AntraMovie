using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IFavoriteService
    {
        Task<List<FavoriteRequestModel>> GetFavoriteByUserId(int uid);

        Task<FavoriteRequestModel> AddFavorite(FavoriteRequestModel model);
        Task<FavoriteRequestModel> check(int id, int MovieId);
    }
}
