
using Business.Users.DTOS;
using Business.Users.Models;

using Business.Users.Repositories;
using Business.Users.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace User.API
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController :  ControllerBase
    {

       
        private readonly IUserService  _userService;
        private readonly IAuthService  _authService;


    

        public UserController( IUserService userService, IAuthService authService)
        {

           
            _userService = userService;
            _authService = authService;

        }


        [HttpGet, Route("Login")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<UserDTO> Login(string userName,string password)
        {

           return await _authService.Login(userName, password);
                              
        }



        [HttpPost, Route("AddUser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<UserDTO>> AddUser( UserModel userModel)
        {
          
            return await _userService.AddUser (userModel);

        }



        [HttpPut, Route("UpdateUser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<UserDTO> UpdateUser(UserModel userModel)
        {
            return await _userService.UpdateUser (userModel);

        }


    }
}
