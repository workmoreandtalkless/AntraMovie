using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
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
    public class AdminController : ControllerBase
    {
        private readonly IBuyService _buyService;
        private readonly IBuyRepository _buyRepository;
        private readonly ICurrentUser _currentUser;
       
        public AdminController(IBuyService buyService , ICurrentUser currentUser,IBuyRepository buyRepository)
        {
            _buyService = buyService;
            _currentUser = currentUser;
            _buyRepository = buyRepository;
        }
        [HttpPost]
        [Route("movie")]
        public async Task<IActionResult> AddMovie([FromBody] APIUserBuyMovieModel model)
        {
            var purchase = await _buyService.AddMovieAPI(model);
            return Ok(purchase);
           /* return CreatedAtRoute("GetMovie", new { id = purchase.Id }, purchase);*/
        }

        [HttpPut("movie")]
        public async Task<IActionResult> upMovie([FromBody] APIUserBuyMovieModel model)
        {
            var purchase = await _buyService.updateMovieAPI(model);
            return Ok(purchase);
            /*return CreatedAtRoute("GetMovie", new { id = purchase.Id }, purchase);*/
        }


        [HttpGet]
        [Route("purchases")]
        public async Task<IActionResult> GetPurchase()
        {
            var purchase = _buyService.GetAll();

           

            return Ok(purchase);

        }


    }
}
