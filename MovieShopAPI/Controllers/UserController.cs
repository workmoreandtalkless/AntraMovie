using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBuyService _buyService;
        private readonly IFavoriteService _favoriteService;
        private readonly IReviewService _reviewService;

        public UserController(IBuyService buyService, IFavoriteService favoriteService, IReviewService reviewService)
        {
            _buyService = buyService;
            _reviewService = reviewService;
            _favoriteService = favoriteService;
        }

        [HttpPost]
        [Route("purchase")]
        public async Task<IActionResult> AddMovie(UserBuyMovieModel model)
        {
            var purchase = await _buyService.AddMovie(model);

            return CreatedAtRoute("GetPurchasedByUserId", new { uid = model.UserId}, purchase);
        }

        [HttpGet]
        [Route("{id}/purchases", Name = "GetPurchasedByUserId")]
        public async Task<IActionResult> GetPurchasedByUserId(int uid)
        {
            var purchase = await _buyService.GetPurchasedMoviesbyUserId(uid);
            if (purchase == null) return NotFound("this user didn't buy any movie");
            return Ok(purchase);
        }

        [HttpPost]
        [Route("favorite")]
        public async Task<IActionResult> AddFavorite(FavoriteRequestModel model)
        {
            var favorite = await _favoriteService.AddFavorite(model);

            return CreatedAtRoute("GetFavoriteByUserId", favorite.userId, favorite);
        }

        [HttpGet]
        [Route("{id}/favorites", Name ="GetFavoriteByUserId")]
        public async Task<IActionResult> GetFavoriteByUserId(int uid)
        {
            var favorite = await _favoriteService.GetFavoriteByUserId( uid);
            if (favorite == null) return NotFound("this user didn't have favorite movie");
            return Ok(favorite);
        }

        [HttpPost]

        [HttpPost]
        [Route("review")]
        public async Task<IActionResult> AddReview(ReviewRequestModel model)
        {
            var review = await _reviewService.AddReview(model);

            return CreatedAtRoute("GetReviewByUserId", review.userId, review);
        }

        [HttpPut]
        [Route("review")]
        public async Task<IActionResult> updateReview(ReviewRequestModel model)
        {
            var review = await _reviewService.AddReview(model);

            return CreatedAtRoute("GetReviewByUserId", review.userId, review);
        }


        [HttpGet]
        [Route("{id}/reviews", Name = "GetReviewByUserId")]
        public async Task<IActionResult> GetReviewByUserId(string id)
        {
            var review = await  _reviewService.GetReviewByUserId(Convert.ToInt32(id));
            if (review == null) return NotFound("this user didn't have review any movie");
            return Ok(review);
        }

        [HttpGet]
        [Route("{id}/movie{MovieId}/favorite")]
        public async Task<IActionResult> CheckIfUserHasFavorite(string id, string MovieId)
        {
            var id1 = Convert.ToInt32(id);
            var MovieId1 = Convert.ToInt32(MovieId);

            var favorite = await _favoriteService.check(id1, MovieId1);
            if (favorite == null) return NotFound("this user have no favorite movie");
            return Ok(favorite);
        }
        [HttpDelete]
        [Route("{userId}/movie/{movieId}")]
        public async Task<IActionResult> DeletMovie(string UserId, string MovieId)
        {
            var uid = Convert.ToInt32(UserId);
            var mid = Convert.ToInt32(MovieId);
            

            var deletedReview = await _reviewService.DeleteReview(uid, mid);
            if (deletedReview == null)
            {
                return NotFound($"there is no review for User {uid} in Movie {mid}");
            }

            return Ok(deletedReview);

        }
        

    }
}
