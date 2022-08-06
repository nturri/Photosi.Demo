
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Business.Products.DTOS
{
    
    public class ProductDTO 
    {
               
        public long Id { get; set; }
  
        public string Name { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public long Pages { get; set; }

        public int PageSize { get; set; }
    }
}
