

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Orders.Entities
{

   
    public class OrderDetail
    {

        [Key]
        public long Id { get; set; }

             
        public int Quantity { get; set; }

     
        public long OrderId { get; set; }

     
        public long ProductId { get; set; }

    }
}
