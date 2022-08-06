
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Business.Orders.Models
{

   
    public class OrderDetailModel 
    {


     
        public long OrderId { get; set; } 

        [Required(ErrorMessage = "required")]
        public int Quantity { get; set; }


        [Required(ErrorMessage = "required")]
        public long ProductId { get; set; }



    }
}
