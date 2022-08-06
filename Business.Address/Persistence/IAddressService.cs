

using Business.Address.DTOS;
using Business.Address.Models;

namespace Business.Address.Persistence
{
    public interface IAddressService
    {

        Task<AddressDTO> AddAddress(AddressModel Address);

        Task<List<AddressDTO>> SearchAddress(SearchAddress searchAddress);

        Task<bool> RemoveAddress(long AddressId);

    }
}
