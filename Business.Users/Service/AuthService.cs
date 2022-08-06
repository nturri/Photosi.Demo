using Business.Users.DTOS;

using Business.Users.Repositories;


namespace Business.Users.Service
{
    public  class AuthService : IAuthService
    {



        private readonly IAuthRepository _authRepository;


        public AuthService(IAuthRepository  authRepository)
        {


            _authRepository = authRepository;
        }

        public async Task<UserDTO> Login(string userName, string password)
        {


            var userLogin = await _authRepository.Login(userName, password);

        


            return userLogin;
        }

    }
}
