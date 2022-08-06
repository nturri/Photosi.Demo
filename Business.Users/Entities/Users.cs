
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Data.Users.Entities
{


    public class User
    {

        public long Id { get; set; }

        public string UserName { get; set; } = string.Empty;


        public string HashedPassword { get; set; } = string.Empty;


        public string EmailAddress { get; set; } = string.Empty;


        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;


        public bool IsActive;

    }
}
