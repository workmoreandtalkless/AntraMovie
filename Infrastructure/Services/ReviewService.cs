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
