using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
   public interface IBuyService
    {
        //public Task<UserBuyMovieModel> GetMovGetPurchaseMovieByMovieId(int mid);
        Task<int> GetAllPurchasedMoviesByUserId(int UserId);
        /* Task AddPurchase(Purchase purchase);*/

        Task<List<MovieCardResponseModel>> GetPurchasedMoviesbyUserId(int uid);
        Task<UserBuyMovieModel> AddMovieAPI(APIUserBuyMovieModel model);
        Task<UserBuyMovieModel> updateMovieAPI(APIUserBuyMovieModel model);

        Task<UserBuyMovieModel> AddMovie(UserBuyMovieModel model);
        Task<List<UserBuyMovieModel>> GetAll();





    }
}
