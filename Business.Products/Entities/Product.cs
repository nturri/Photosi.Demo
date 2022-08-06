
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Data.Products.Entities
{
 
    public class Product 
    {
        
        public long Id { get; set; }

    
        public string Name { get; set; } = string.Empty;

     
        public string Category { get; set; } = string.Empty;
          
   
        public decimal Price { get; set; }
    }
}
