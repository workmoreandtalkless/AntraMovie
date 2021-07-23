using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IReviewRepository : IAsyncRepository<Review>
    {
        Task<IEnumerable<Review>> GetReviewByMovieId(int mid);
        Task<IEnumerable<Review>> GetReviewByUserId(int uid);

        Task<Review> GetReviewById(int uid, int mid);
    }
}
