
using AutoMapper;
using Business.Users.DTOS;
using Business.Users.Exceptions;
using Business.Users.Models;

using Business.Users.Security;
using Data.User.Persistence;
using Data.User.Repositories;
using Data.Users.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Business.Users.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {

        private readonly ILogger<UserRepository> _logger;

        public UserRepository(MySqlDbContext context, ILogger<UserRepository> logger) : base(context)
        {
            _logger = logger;
        }


        //metodo non esposto serve nei controller serve per i test
        public async Task<bool> DeleteForUserName(String userName)
        {

          

           var lista = _context.Users.Where(u => u.UserName == userName).ToList();

            foreach (var entity in lista)
            {
                _context.Remove(entity);
            
            }

            await _context.SaveChangesAsync();


            return true;


        }

        public async Task<UserDTO> AddUser(UserModel userModel)
        {

            try
            {

                var oldUser = await _context.Users.Where(u => u.UserName == userModel.UserName || u.EmailAddress == userModel.EmailAddress).FirstOrDefaultAsync();

                if (oldUser != null)
                {
                    throw new Exception("attenzione: username / email e già presente");

                }



                var user = ToUser(userModel);

                var sut = new BCryptHashManager();

                user.HashedPassword = sut.HashString(userModel.Password);

              

                _context.Users.Add(user);

                await _context.SaveChangesAsync();

                return ToUserDTO(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " " + ex.InnerException);


                return null;

            }



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
                var user = await _context.Users.Where(u => u.UserName == userName).FirstOrDefaultAsync();


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



        public async Task<UserDTO> UpdateUser(UserModel userModel)
        {

            try
            {
                var user = await _context.Users.Where(u => u.UserName == userModel.UserName).FirstOrDefaultAsync();

                if (user==null)
                    throw new Exception("attenzione: user non trovato");

                var sut = new BCryptHashManager();

                user.EmailAddress = userModel.EmailAddress;
                user.FirstName = userModel.FirstName;
                user.LastName = userModel.LastName;
                user.HashedPassword = sut.HashString(userModel.Password);


                await _context.SaveChangesAsync();


                return ToUserDTO(user);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                throw new Exception(e.Message, e);


            }
        }
    }
}
