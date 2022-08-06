

namespace Business.Address.DTOS
{
    public class AddressDTO
    {

        public long Id { get; set; }

       
        public string Address1 { get; set; } = string.Empty;


        public string City { get; set; } = string.Empty;


        public string PostalCode { get; set; } = string.Empty;


        public string Country { get; set; } = string.Empty;

        public long Pages { get; set; }

        public int PageSize { get; set; }

    }
}
