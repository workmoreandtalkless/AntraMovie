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
    public class AccountController : ControllerBase
    {
        private readonly IUserService  _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }


        public async Task<IActionResult> RegisterUser( UserRegisterRequestModel model)
        {
            var createUser = await _userService.RegisterUser(model);
            //send the url for newly created user also
            //5000
            return CreatedAtRoute("GetUser", new { id = createUser.Id }, createUser );

        }

        [HttpGet]
        [Route("{id:int}", Name = "GetUser")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound($"User does not exists for {id}");
            }

            return Ok(user);
        }

    }
}
