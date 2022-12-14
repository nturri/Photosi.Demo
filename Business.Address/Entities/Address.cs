

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Data.Address.Entities
{
  
    public class Address
    {

        [Key]
    
        public long Id { get; set; } 

    
        public string Address1 { get; set; } = string.Empty;

             
        public string City { get; set; } = string.Empty;

  
        public string PostalCode { get; set; } = string.Empty;


        public string Country { get; set; } = string.Empty;
  

          
    }
}
