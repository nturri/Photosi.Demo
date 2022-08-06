
using AutoMapper;
using Business.Users.DTOS;
using Business.Users.Exceptions;
using Business.Users.Models;

using Business.Users.Security;

using Data.User.Persistence;
using Data.User.Repositories;
using Data.Users.Entities;
using Microsoft.Extensions.Logging;


namespace Business.Users.Repositories
{
    public class AuthRepository : RepositoryBase<User>, IAuthRepository
    {

        private readonly ILogger<AuthRepository> _logger;

        public AuthRepository(MySqlDbContext context, ILogger<AuthRepository> logger) : base(context)
        {
            _logger = logger;
        }

        private UserDTO ToUserDTO(User user)
        {
            //Initialize the mapper
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<User, UserDTO>()
                );


            //Using automapper
            var mapper = new Mapper(config);
            var userDTO = mapper.Map<UserDTO>(user);

            return userDTO;

        }

        private User ToUser(UserModel user)
        {
            //Initialize the mapper
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<UserModel, User>()
                );


            //Using automapper
            var mapper = new Mapper(config);
            var _user = mapper.Map<User>(user);

            return _user;
        }




        public async Task<UserDTO> Login(string userName, string password)
        {


            try
            {


                //attenzione mysql ef non supporta alcune funzioni avanzate sulle stringhe
                var user = _context.Users.Where(u => u.UserName == userName).FirstOrDefault();


                var sut = new BCryptHashManager();



                if (!sut.ValidateHash(user.HashedPassword, password))
                {
                    throw new InvalidCredentialsException();

                }

                var userDTO = ToUserDTO(user);

                return userDTO;



            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                throw new InvalidCredentialsException(e);
            }



            throw new NotImplementedException();
        }



    }
}
