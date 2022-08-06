
using System.ComponentModel.DataAnnotations;


namespace Business.Orders.Models
{
    public class SearchOrder
    {

        [Required(ErrorMessage = "ordine id mancante ")]
        public string OrderId { get; set; } = string.Empty;

        [Required(ErrorMessage = "user id mancante ")]
        public string UserId { get; set; } = string.Empty;

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 10;

    }
}
