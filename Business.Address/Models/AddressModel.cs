
using System.ComponentModel.DataAnnotations;


namespace Business.Address.Models
{
    public class AddressModel
    {


        public long Id { get; set; }


        [MinLength(2, ErrorMessage = "Il numero minimo di caratteri è 5")]
        [MaxLength(30, ErrorMessage = "Il numero massimo di caratteri è 255")]
        public string Address1 { get; set; } = string.Empty;

        [MinLength(2, ErrorMessage = "Il numero minimo di caratteri è 5")]
        [MaxLength(30, ErrorMessage = "Il numero massimo di caratteri è 255")]
        public string City { get; set; } = string.Empty;


        //cap italiano
        [MinLength(5, ErrorMessage = "Il numero minimo di caratteri è 5")]
        [MaxLength(5, ErrorMessage = "Il numero massimo di caratteri è 5")]
        public string PostalCode { get; set; } = string.Empty;

        [MinLength(2, ErrorMessage = "Il numero minimo di caratteri è 2")]
        [MaxLength(30, ErrorMessage = "Il numero massimo di caratteri è 255")]
        public string Country { get; set; } = string.Empty;

    }
}
