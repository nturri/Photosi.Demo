
using Business.Users.DTOS;
using Business.Users.Models;
using Business.Users.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebPhotosi.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController :  ControllerBase
    {

       
        private readonly IUserRepository _userRepository;
        public UserController( IUserRepository userRepository)
        {
          
            _userRepository = userRepository;
        }


        [HttpGet, Route("Login")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<UserDTO> Login(string userName,string password)
        {

           return await _userRepository.Login(userName, password);
                              
        }



        [HttpPost, Route("AddUser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<UserDTO>> AddUser( UserModel userModel)
        {
          
            return await _userRepository.AddUser (userModel);

        }



        [HttpPut, Route("UpdateUser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<UserDTO> UpdateUser(UserModel userModel)
        {
            return await _userRepository.UpdateUser (userModel);

        }


    }
}
