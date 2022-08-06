
using AutoMapper;
using Business.Products.DTOS;
using Business.Products.Models;
using Business.Products.Persistence;
using Data.Products.Entities;
using Data.Products.Persistence;
using Data.Products.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Business.Products.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {

        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(MySqlDbContext context, ILogger<ProductRepository> logger) : base(context)
        {
            _logger = logger;
        }

  
       

        private ProductDTO ToProductDTO(Product product)
        {
            //Initialize the mapper
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Product, ProductDTO>()
                );


            //Using automapper
            var mapper = new Mapper(config);
            var productDTO = mapper.Map<ProductDTO>(product);

            return productDTO;

        }


        private ProductDTO ToProductDTO(Product product,int page,int pageSize)
        {
          var productDto = ToProductDTO(product);

            productDto.Pages = page;
            productDto.PageSize = pageSize;

            return productDto;

        }

        private Product ToProduct(ProductModel product)
        {
            //Initialize the mapper
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<ProductModel, Product>()
                );


            //Using automapper
            var mapper = new Mapper(config);
            var _product = mapper.Map<Product>(product);

            return _product;
        }



        public async  Task<ProductDTO> AddProduct(ProductModel product)
        {
            var entity = ToProduct(product);

                                             

             _context.Products.Add(entity);
             

             await _context.SaveChangesAsync();

            return ToProductDTO(entity); 
         
        }

        public async Task<ProductDTO> UpdateProduct(ProductModel productModel)
        {

            try
            {
                var product = _context.Products .Where(p => p.Id == productModel.Id).FirstOrDefault();

                if (product == null)
                    throw new Exception("attenzione: prodotto non trovato");

      

                product.Name = productModel.Name;
                product.Price = productModel.Price;
                product.Category = productModel.Category;

                

                await _context.SaveChangesAsync();


                return ToProductDTO(product);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                throw new Exception(e.Message, e);


            }

        }

        public async Task<bool> RemoveProduct(long productId)
        {
            try
            {

                var product = _context.Products.Where(p => p.Id == productId).FirstOrDefault();

            if (product == null)
                throw new Exception("attenzione: prodotto non trovato");


            _context.Remove(product);

            await _context.SaveChangesAsync();

            return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                throw new Exception(e.Message, e);


            }

        }



        public async Task<List<ProductDTO>> SearchProduct(SearchProduct searchProduct)
        {


            var query = _context.Products.AsQueryable();

            if (!String.IsNullOrEmpty(searchProduct.Name))
            {
                query = query.Where(c => c.Name.ToLower().IndexOf(searchProduct.Name.ToLower()) >= 0);
            }


            if (!String.IsNullOrEmpty(searchProduct.Category))
            {
                query = query.Where(c => c.Category == searchProduct.Category);
            }

            if (searchProduct.PriceMin > 0)
            {
                query = query.Where(c => c.Price >= searchProduct.PriceMin);
            }

            if (searchProduct.PriceMax > 0)
            {
                query = query.Where(c => c.Price <= searchProduct.PriceMax);
            }


            if (searchProduct.Page < 1)
                searchProduct.Page = 1;

            if (searchProduct.PageSize < 1)
                searchProduct.PageSize = 1;


            var count = query.Count();

            var pages = (count / searchProduct.PageSize);

            if ((count % searchProduct.PageSize) > 0)
                pages = pages+1 ;


            var prodotti = await query
                  .Skip((searchProduct.Page - 1) * searchProduct.PageSize)
                  .Take(searchProduct.PageSize)
                  .ToListAsync();

                     

           return prodotti.Select(p => ToProductDTO(p, pages, searchProduct.PageSize) ).ToList();

        



        }
    }
}
