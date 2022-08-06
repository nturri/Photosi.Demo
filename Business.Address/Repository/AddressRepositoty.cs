using AutoMapper;
using Business.Address.DTOS;
using Business.Address.Persistence;
using Microsoft.Extensions.Logging;


using Business.Address.Models;
using Data.Address.Repositories;
using Data.Address.Persistence;

using Microsoft.EntityFrameworkCore;

namespace Business.Address.Repositories
{
    public class AddressRepository : RepositoryBase<Data.Address.Entities.Address>, IAddressRepository
    {

        private readonly ILogger<AddressRepository> _logger;

        public AddressRepository(MySqlDbContext context, ILogger<AddressRepository> logger) : base(context)
        {
            _logger = logger;
        }


        private AddressDTO ToAddressDTO(Data.Address.Entities.Address Address)
        {
            //Initialize the mapper
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Data.Address.Entities.Address, AddressDTO>()
                );


            //Using automapper
            var mapper = new Mapper(config);
            var AddressDTO = mapper.Map<AddressDTO>(Address);

            return AddressDTO;

        }


        private AddressDTO ToAddressDTO(Data.Address.Entities.Address address, int page, int pageSize)
        {
            var addressDto = ToAddressDTO(address);

            addressDto.Pages = page;
            addressDto.PageSize = pageSize;

            return addressDto;

        }


        private Data.Address.Entities.Address ToAddress(AddressModel Address)
        {
            //Initialize the mapper
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<AddressModel, Data.Address.Entities.Address>()
                );


            //Using automapper
            var mapper = new Mapper(config);
            var _Address = mapper.Map<Data.Address.Entities.Address>(Address);

            return _Address;
        }
        


        public async Task<AddressDTO> AddAddress(AddressModel Address)
        {
            var entity = ToAddress(Address);



            _context.Address.Add(entity);


            await _context.SaveChangesAsync();


            return ToAddressDTO(entity);



        }

      

        public async Task<bool> RemoveAddress(long AddressId)
        {
            try
            {

                var Address = await _context.Address.Where(p => p.Id == AddressId).FirstOrDefaultAsync();

                if (Address == null)
                    throw new Exception("attenzione: prodotto non trovato");


                _context.Remove(Address);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                throw new Exception(e.Message, e);


            }

        }

        public async Task<List<AddressDTO>> SearchAddress(SearchAddress searchAddress) 
        {

          

             var query = _context.Address.AsQueryable();

            if (!String.IsNullOrEmpty(searchAddress.Addres))
            {
                query = query.Where(a => a.Address1.ToLower().Contains(searchAddress.Addres.ToLower()));

                var cazzo2 = query.ToList();
            }

            if (!String.IsNullOrEmpty(searchAddress.Country))
            {
                 query = query.Where(a => a.Country.ToLower()==searchAddress.Country.ToLower());
     }

            if (!String.IsNullOrEmpty(searchAddress.City))
            {
                query = query.Where(a => a.City.ToLower()==searchAddress.City.ToLower());
            }

            if (!String.IsNullOrEmpty(searchAddress.PostalCode))
            {
               query = query.Where(a => a.PostalCode==searchAddress.PostalCode);

               

            }

            if (searchAddress.Page < 1)
                searchAddress.Page = 1;

            if (searchAddress.PageSize < 1)
                searchAddress.PageSize = 1;


            var count = query.Count();

            var pages = (count / searchAddress.PageSize);

            if ((count % searchAddress.PageSize) > 0)
                pages = pages + 1;


            var  indirizzi = await query
                  .Skip((searchAddress.Page - 1) * searchAddress.PageSize)
                  .Take(searchAddress.PageSize).ToListAsync();


           return indirizzi.Select(p => ToAddressDTO(p, searchAddress.Page, pages)).ToList();

          

        }


     
    }
}
