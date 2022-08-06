using Business.Address.DTOS;
using Business.Address.Models;
using Business.Address.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Address.Service
{
    public class AddressService : IAddressService
    {

        private readonly IAddressRepository _addressRepository;


        public AddressService(IAddressRepository addressRepository)
        {

            _addressRepository = addressRepository;
        }


        public async Task<AddressDTO> AddAddress(AddressModel address)
        {
            return  await _addressRepository.AddAddress(address);
        }

        public Task<bool> RemoveAddress(long AddressId)
        {
            return _addressRepository.RemoveAddress(AddressId);
        }

        public Task<List<AddressDTO>> SearchAddress(SearchAddress searchAddress)
        {
            return _addressRepository.SearchAddress(searchAddress);
        }
    }
}
