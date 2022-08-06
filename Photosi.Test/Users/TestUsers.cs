using NUnit.Framework;


using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;

using System.Reflection;

using Business.Users.Repositories;

using Business.Users.Models;
using Data.User.Persistence;

using Business.Users.Service;
using User.API;

namespace Photosi.Test
{

    public class TestUsers
    {

        private readonly IUserService _userService;

        private readonly IAuthService _authService;


        private readonly UserController _userController;


        public void OneTimeSetUp()
        {
            var testDllName = Assembly.GetAssembly(GetType())
                                      .GetName()
                                      .Name;
            var configName = testDllName + ".dll.config";
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", configName);
        }





        public TestUsers()
        {
            OneTimeSetUp();

                        
            var serviceProvider = new ServiceCollection()
             .AddLogging()
             .AddSingleton<IUserRepository, UserRepository>()
             .AddSingleton<IAuthRepository, AuthRepository>()
             .AddSingleton<IUserService, UserService>()
             .AddSingleton<IAuthService, AuthService>()
             .AddDbContext< MySqlDbContext > (options => options.UseInMemoryDatabase(databaseName: "PhotoSi"))
                         

             .BuildServiceProvider();

           _userService = serviceProvider.GetService<IUserService>();
           _authService = serviceProvider.GetService<IAuthService>();


           _userController = new UserController(_userService, _authService);




        }

        public static string CreateRandomPassword(int length = 15)
        {
            // Create a string of characters, numbers, special characters that allowed in the password  
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            Random random = new Random();

            // Select one random character at a time from the string  
            // and create an array of chars  
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }



        [Test]
        public async Task users()
        {


            UserModel user = new UserModel();

            user.UserName = "nturri";
            user.EmailAddress = "nicola.turri@alten.it";
            user.FirstName = "nicola";
            user.LastName = "turri";
            user.Password = CreateRandomPassword(10);
            user.ConfirmPassword = user.Password;

           
            var _userDto = await _userController.AddUser(user);

            if (_userDto == null)
            {
                Assert.IsTrue(false);
                return;
            }


            user.EmailAddress = "nturri1306@gmail.com";

            var userDto = await _userController.UpdateUser(user);


            if (userDto == null)
            {
                Assert.IsTrue(false);
                return;
            }

            
            var userLogin = await _userController.Login(user.UserName, user.Password);

            if (userLogin == null)
            {
                Assert.IsTrue(false);
                return;
            }


            Assert.IsTrue(userLogin!=null);



        }








    }

    }
