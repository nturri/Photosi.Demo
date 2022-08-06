

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Data.Orders.Entities
{
  
    public  class Order 
    {
        [Key]
        public long OrderId { get; set; } 

        public long UserId { get; set; }

 
        public long AddressId { get; set; } 
     
        public virtual ICollection<OrderDetail>? OrderDetail { get; set; }


        public string UserName { get; set; } = string.Empty;

    }
}
