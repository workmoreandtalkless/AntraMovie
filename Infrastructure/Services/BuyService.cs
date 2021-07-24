using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
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

        public async Task<UserBuyMovieModel> AddMovie(UserBuyMovieModel model)
        {
            var purchase = await _buyRepository.CheckMoviePurchaseForUser(model.UserId, model.MovieId);

            var purchase1 = await _buyRepository.GetById(model.UserId, model.MovieId);

            if (purchase)
            {
                throw new ConflictException("User already purchased this movie");
            }

            var entity = new Purchase
            {
                PurchaseDateTime = DateTime.Now,
                MovieId = model.MovieId,
                PurchaseNumber = Guid.NewGuid(),
                TotalPrice = purchase1.TotalPrice,
                UserId = model.UserId
            };
            var userbuyModel = new UserBuyMovieModel
            {
                PurchaseDateTime = DateTime.Now,
                MovieId = model.MovieId,
                PurchaseNumber = Guid.NewGuid(),
                TotalPrice = purchase1.TotalPrice,
                UserId = model.UserId

            };
            await _buyRepository.AddAsync(entity);

            return userbuyModel;
        }

        public async Task<UserBuyMovieModel> AddMovieAPI(APIUserBuyMovieModel model)
        {
            var purchase = await _buyRepository.CheckMoviePurchaseForUser(model.UserId, model.MovieId);

            /*var purchase1 = await _buyRepository.GetById(model.UserId, model.MovieId);*/

            if (purchase)
            {
                throw new ConflictException("User already purchased this movie");
            }

            var entity = new Purchase
            {
                PurchaseDateTime = DateTime.Now,
                MovieId = model.MovieId,
                PurchaseNumber = Guid.NewGuid(),
                TotalPrice = model.TotalPrice,
                UserId = model.UserId
            };
            var userbuyModel = new UserBuyMovieModel
            {
                PurchaseDateTime = DateTime.Now,
                MovieId = model.MovieId,
                PurchaseNumber = Guid.NewGuid(),
                TotalPrice = model.TotalPrice,
                UserId = model.UserId

            };
            await _buyRepository.AddAsync(entity);

            return userbuyModel;
        }
        public async Task<UserBuyMovieModel> updateMovieAPI(APIUserBuyMovieModel model)
        {
           /* var purchase = await _buyRepository.CheckMoviePurchaseForUser(model.UserId, model.MovieId);

            if (purchase)
            {
                var purchase1 = await _buyRepository.GetById(model.UserId, model.MovieId);
                await _buyRepository.DeleteAsync(purchase1);
            }*/
            var entity = new Purchase
            {
                PurchaseDateTime = DateTime.Now,
                MovieId = model.MovieId,
                PurchaseNumber = Guid.NewGuid(),
                TotalPrice = model.TotalPrice,
                UserId = model.UserId
            };
            var userbuyModel = new UserBuyMovieModel
            {
                PurchaseDateTime = DateTime.Now,
                MovieId = model.MovieId,
                PurchaseNumber = Guid.NewGuid(),
                TotalPrice = model.TotalPrice,
                UserId = model.UserId

            };

            await _buyRepository.AddAsync(entity);

            return userbuyModel;
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

        public async Task<List<UserBuyMovieModel>> GetAll()
        {
            var models = await _buyRepository.GetAll();

            var userbuyModel = new List<UserBuyMovieModel>();
            foreach (var model in models)
            {
                userbuyModel.Add(new UserBuyMovieModel
                {
                    PurchaseDateTime = DateTime.Now,
                    MovieId = model.MovieId,
                    PurchaseNumber = Guid.NewGuid(),
                    TotalPrice = model.TotalPrice,
                    UserId = model.UserId

                });

            }
            return userbuyModel;
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
