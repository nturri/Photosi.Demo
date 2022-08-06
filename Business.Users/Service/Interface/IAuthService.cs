using Business.Users.DTOS;
using Business.Users.Models;

namespace Business.Users.Service
{
    

    public interface IAuthService
    {
        
       
        Task<UserDTO> Login(string userName,string password);




    }
}
