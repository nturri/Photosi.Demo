
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Business.Users.Models
{

  
    public class UserModel 
    {
      

        [MinLength(5, ErrorMessage = "Il numero minimo di caratteri è 5")]
        [MaxLength(30, ErrorMessage = "Il numero massimo di caratteri è 30")]
    
  
        public string UserName { get; set; } = string.Empty;


        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Il numero minimo di caratteri è 10", MinimumLength = 10)]
        [DataType(DataType.Password)]
        [NotMapped]
        public string Password { get; set; } = string.Empty;

        [Required]
        [StringLength(255, ErrorMessage = "Il numero minimo di caratteri è 10", MinimumLength = 10)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; } = string.Empty;



        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Column("EMAIL")]
        public string EmailAddress { get; set; } = string.Empty;



        [MinLength(2, ErrorMessage = "Il numero minimo di caratteri è 5")]
        [MaxLength(30, ErrorMessage = "Il numero massimo di caratteri è 30")]

        [Column("FIRSTNAME")]
        public string FirstName { get; set; } = string.Empty;




        [MinLength(2, ErrorMessage = "Il numero minimo di caratteri è 5")]
        [MaxLength(30, ErrorMessage = "Il numero massimo di caratteri è 30")]
        [Column("LASTNAME")]
        public string LastName { get; set; } = string.Empty;

  

    }
}
