using Business.Address.DTOS;
using Business.Address.Models;
using Business.Address.Persistence;
using Microsoft.AspNetCore.Mvc;

using System.Net;

namespace Address.API
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AddressController : ControllerBase
    {


        private readonly IAddressService _AddressService;
        public AddressController(IAddressService AddressService)
        {

            _AddressService = AddressService;
        }


        [HttpPost, Route("AddAddress")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<AddressDTO>> Add(AddressModel addressModel)
        {


            return await _AddressService.AddAddress (addressModel);

        }

    


        [HttpDelete, Route("RemoveAddress")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<bool> RemoveAddress(long AddressId)
        {


            return await _AddressService.RemoveAddress(AddressId);

        }

        [HttpPost, Route("SearchAddress")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<List<AddressDTO>> SearchAddress(SearchAddress search)
        {


            return await _AddressService.SearchAddress(search);

        }



    }
}
