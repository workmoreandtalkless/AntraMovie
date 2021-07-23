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
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMovieRepository _movieRepository;

        public async Task<ReviewRequestModel> AddReview(ReviewRequestModel model)
        {
            
            var entity = new Review
            {
                MovieId = model.movieId,
                UserId = model.userId,
                Rating = model.Rating,
                ReviewText = model.reviewText
            };
            await _reviewRepository.AddAsync(entity);

            return model;
        }

        public async Task<ReviewModel> DeleteReview(int uid, int mid)

        {

            var review = await _reviewRepository.GetReviewById(uid, mid);
            if (review == null)
            {
                return null;
            }
            var entity = new Review
            {
                MovieId = review.MovieId,
                UserId = review.UserId,
                Rating = review.Rating,
                ReviewText = review.ReviewText
            };
            var reviewModel = new ReviewModel
            {
                MovieId = review.MovieId,
                UserId = review.UserId,
                Rating = review.Rating,
                ReviewText = review.ReviewText
            };
            await _reviewRepository.DeleteAsync(entity);
            return reviewModel;
        }

        public async Task<IEnumerable<ReviewRequestModel>> GetReviewByUserId(int uid)
        {
            var reviews = await _reviewRepository.GetReviewByUserId(uid);

            var reviewModel = new List<ReviewRequestModel>();

            foreach (var review in reviews)
            {
                reviewModel.Add(
                    new ReviewRequestModel
                {
                    movieId = review.MovieId,
                    userId = review.UserId,
                    Rating = review.Rating,
                    reviewText = review.ReviewText

                });
            }
            return reviewModel;


        }

        public async Task<IEnumerable<ReviewModel>> GetReviewsbyMovieId(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);

            var reviews =await _reviewRepository.GetReviewByMovieId(id);

            var reviewModel = new List<ReviewModel>();

            foreach(var review in reviews)
            {
                reviewModel.Add(new ReviewModel
                {
                    MovieId = review.MovieId,
                    UserId = review.UserId,
                    Rating = review.Rating,
                    ReviewText = review.ReviewText

                });
            }
            return reviewModel;
        }

       
    }
}
