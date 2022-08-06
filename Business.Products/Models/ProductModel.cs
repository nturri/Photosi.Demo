
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Text.Json.Serialization;


namespace Business.Products.Models
{

  
    public class ProductModel 
    {

       
        public long  Id { get; set; } 

        [MinLength(5, ErrorMessage = "Il numero minimo di caratteri è 5")]
        [MaxLength(30, ErrorMessage = "Il numero massimo di caratteri è 255")]
        public string Name { get; set; } = string.Empty;

        [MinLength(2, ErrorMessage = "Il numero minimo di caratteri è 5")]
        [MaxLength(30, ErrorMessage = "Il numero massimo di caratteri è 255")]
        public string Category { get; set; } = string.Empty;


        [Range(0.1, 1000, ErrorMessage = "Prezzo compreso tra  $0.1 and $1000")]
        public decimal Price { get; set; }



    }
}
