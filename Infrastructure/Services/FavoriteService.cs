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
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteService(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task<FavoriteRequestModel> check(int id, int MovieId)
        {
            var favorite = await _favoriteRepository.FindFavorite(id, MovieId);

            var model = new FavoriteRequestModel
            {
                movieId = favorite.MovieId,
                userId = favorite.UserId
            };

            return model;
        }

        public async Task<FavoriteRequestModel> AddFavorite(FavoriteRequestModel model)

        {
            var entity = new Favorite
            {
                MovieId = model.movieId,
                UserId = model.userId,
            };
            await _favoriteRepository.AddAsync(entity);
            return model;
        }

        public async Task<List<FavoriteRequestModel>> GetFavoriteByUserId(int uid)
        {
            var favoritemodels = await _favoriteRepository.GetFavoriteByUserId(uid);

            var movieCreates = new List<FavoriteRequestModel>();

            foreach(var favoritemodel in favoritemodels)
            {
                movieCreates.Add(new FavoriteRequestModel
                {
                    userId = favoritemodel.UserId,
                    movieId = favoritemodel.MovieId,
                }) ;
            }

            return movieCreates;
            
        }
    }
}
