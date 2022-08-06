using Business.Users.DTOS;
using Business.Users.Models;

namespace Business.Users.Repositories
{
    

    public interface IAuthRepository
    {
       
       
        Task<UserDTO> Login(string userName,string password);



    }
}
