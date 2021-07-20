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

        public BuyService(IBuyRepository buyRepository)
        {
            _buyRepository = buyRepository;
        }
        public async Task<UserBuyMovieModel> GetMovieById(int mid)
        {
            var purchase = await _buyRepository.ListAsync(p => p.MovieId == mid);
            var buymovie = new UserBuyMovieModel();
        }

    }
}
