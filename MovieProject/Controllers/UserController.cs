using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Controllers
{
    public class UserController : Controller
    {
        private readonly ICurrentUser _currentUser;
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;
        private readonly IBuyService _buyService;
        private readonly IBuyRepository _buyRepository;
        private readonly IMovieRepository _movieRepository;

        public UserController(ICurrentUser currentUser, IUserService userService,IMovieService movieService, IMovieRepository movieRepository, IBuyService buyService, IBuyRepository buyRepository)
        {
            _currentUser = currentUser;
            _userService = userService;
            _movieService = movieService;
            _buyService = buyService;
            _movieRepository = movieRepository;
            _buyRepository = buyRepository;
        }

        [HttpGet]
        public  IActionResult BuyMovie(int mid)
        {
            var purchaseMovie = new UserBuyMovieModel
            {
                MovieId = mid,
                UserId = _currentUser.UserId,
                /*TotalPrice = _movieService.GetMovieDetails(mid)*/
                TotalPrice = 0,/*MovieRepository.(_movieRepository.GetByIdAsync(mid)).Price.GetType().Name;*/
                //TotalPrice = _movieService.GetMovieDetails(mid),
            };

            return View(purchaseMovie);
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmPurchase(UserBuyMovieModel model)
        {
            if (!_currentUser.IsAuthenticated)
            {
                return LocalRedirect("~/Account/Login");
            }
            var purchase = new Purchase
            {
                MovieId = model.MovieId,
                UserId = model.UserId,
                PurchaseDateTime = DateTime.Now,
                PurchaseNumber = Guid.NewGuid(),
                TotalPrice = model.TotalPrice
            };

            await _buyRepository.AddAsync(purchase);

            return LocalRedirect("~/");


        }

        public async Task<IActionResult> PurchasedMovies(int uid)
        {
           
            var moviecards = await _buyService.GetPurchasedMoviesbyUserId(uid);
            return View(moviecards);
        }
    }
}
