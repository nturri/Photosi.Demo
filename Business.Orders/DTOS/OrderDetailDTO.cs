

namespace Business.Orders.DTOS
{
    public class OrderDetailDTO
    {

      
        public int Quantity { get; set; }

        
        public string OrderId { get; set; } = string.Empty;

       
        public string ProductId { get; set; } = string.Empty;
    }
}
