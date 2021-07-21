using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class BuyService : IBuyService
    {
        private readonly IBuyRepository _buyRepository;
        private readonly IMovieRepository _movieRepository;

        public BuyService(IBuyRepository buyRepository, IMovieRepository movieRepository)
        {
            _buyRepository = buyRepository;
            _movieRepository = movieRepository;
        }

       /* public Task AddPurchase(Purchase purchase)
        {
            _buyRepository.AddAsync(purchase);
            return 
        }*/

        public async Task<int> GetAllPurchasedMoviesByUserId(int UserId)
        {
            var movies = await _buyRepository.GetPurchasesByuserId(UserId);
            return movies.Count();
        }

        public async Task<List<MovieCardResponseModel>> GetPurchasedMoviesbyUserId(int uid)
        {
            var purchases = await _buyRepository.GetPurchasesByuserId(uid);

            var moviecards = new List<MovieCardResponseModel>();

            foreach(var purchase in purchases)
            {
                var id = purchase.MovieId;
                Movie purchasemovie = await _movieRepository.GetByIdAsync(id);
                moviecards.Add(new MovieCardResponseModel()
                {
                    Id = purchasemovie.Id,
                    Title = purchasemovie.Title,
                    PosterUrl = purchasemovie.PosterUrl,
                    Budget = purchasemovie.Budget.GetValueOrDefault()
                });

            }
            return moviecards;
        }


        /* public async Task<UserBuyMovieModel> GetPurchaseMovieByMovieId(int mid)
{
    //var purchase = await _buyRepository.ListAsync(p => p.MovieId == mid);
    var buymovie = new UserBuyMovieModel
    {
        UserId = _cur
    }
UserId = purchase.UserId,
PurchaseNumber = purchase.PurchaseNumber
TotalPrice
 PurchaseDateTime
 MovieId

    var buymovies = new List<UserBuyMovieModel>();


    foreach (var purchase in purchases)
    {
        buymovie.UserId = purchase.userId;
        buymovie.TotalPrice = purchase.TotalPrice;
        buymovie.MovieId = purchase.MovieId;

    }

    return buymovie;

}*/

    }
}
