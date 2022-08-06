using Business.Address.DTOS;
using Business.Address.Models;
using Business.Address.Persistence;
using Microsoft.AspNetCore.Mvc;

using System.Net;

namespace WebPhotosi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AddressController : ControllerBase
    {


        private readonly ILogger<AddressController> _logger;

        private readonly IAddressRepository _AddressRepository;
        public AddressController(ILogger<AddressController> logger, IAddressRepository AddressRepository)
        {
            _logger = logger;
            _AddressRepository = AddressRepository;
        }



        [HttpPost, Route("AddAddress")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> Add(AddressModel AddressModel)
        {


            return await _AddressRepository.AddAddress(AddressModel);

        }




     /*   [HttpPut, Route("UpdateAddress")]

        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<AddressDTO> Update(AddressModel AddressModel)
        {


            return await _AddressRepository.UpdateAddress(AddressModel);

        }*/

        [HttpDelete, Route("RemoveAddress")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<bool> RemoveAddress(string AddressId)
        {


            return await _AddressRepository.RemoveAddress(AddressId);

        }

        [HttpPost, Route("SearchAddress")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<List<AddressDTO>> SearchAddress(SearchAddress search)
        {


            return await _AddressRepository.SearchAddress(search);

        }



    }
}
