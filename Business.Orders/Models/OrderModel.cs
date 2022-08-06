

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Business.Orders.Models
{
    public class OrderModel
    {

    
        public long OrderId { get; set; }

        [Required(ErrorMessage = "user mancante ")]
        public long UserId { get; set; }

        
        [Required(ErrorMessage = "user name mancante ")]
        public string UserName { get; set; } = string.Empty;


        [Required(ErrorMessage = "address mancante ")] 

        public long AddressId { get; set; }


       
        [Required(ErrorMessage = "nessun dettaglio ordine specificato")]
        public virtual ICollection<OrderDetailModel>? OrderDetail { get; set; }


    }
}
