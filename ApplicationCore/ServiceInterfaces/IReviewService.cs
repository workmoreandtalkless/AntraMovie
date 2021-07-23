using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewModel>> GetReviewsbyMovieId(int id);
        Task<ReviewRequestModel> AddReview(ReviewRequestModel model);
        Task<IEnumerable<ReviewRequestModel>> GetReviewByUserId(int uid);
        Task<ReviewModel> DeleteReview(int uid, int mid);
    }
}
