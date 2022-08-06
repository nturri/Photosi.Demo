

namespace Business.Orders.DTOS
{
    public class OrderDTO
    {


        public long OrderId { get; set; }

     
        public string UserId { get; set; } = string.Empty;

       
        public string AddressId { get; set; } = string.Empty;

      
        public virtual ICollection<OrderDetailDTO>? OrderDetail { get; set; }

    }
}
