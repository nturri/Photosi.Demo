using Business.Users.DTOS;
using Business.Users.Models;

namespace Business.Users.Repositories
{
    

    public interface IUserRepository 
    {
        
        Task<UserDTO> AddUser(UserModel user);
             
  
        Task<UserDTO> UpdateUser(UserModel user);


        Task<bool> DeleteForUserName(String userName);



    }
}
