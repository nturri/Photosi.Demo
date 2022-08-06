using Business.Users.DTOS;
using Business.Users.Models;

using Business.Users.Repositories;
using Microsoft.Extensions.Logging;


namespace Business.Users.Service
{
    public class UserService : IUserService
    {



        private readonly IUserRepository _userRepository;



        public UserService(IUserRepository userRepository)
        {


            _userRepository = userRepository;
        }


        public async Task<UserDTO> AddUser(UserModel userModel)
        {


            return await _userRepository.AddUser(userModel);

        }

        public Task<bool> DeleteForUserName(string userName)
        {
            return _userRepository.DeleteForUserName(userName);
        }

        public async Task<UserDTO> UpdateUser(UserModel userModel)
        {


            return await _userRepository.UpdateUser(userModel);

        }




    }
}


