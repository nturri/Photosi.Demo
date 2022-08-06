using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Products.Models
{
    public class SearchProduct
    {
       
        public string Name { get; set; } = string.Empty;

    
        public string Category { get; set; } = string.Empty;

        public decimal PriceMin { get; set; }


        public decimal PriceMax { get; set; }

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 10; 
    }
}
