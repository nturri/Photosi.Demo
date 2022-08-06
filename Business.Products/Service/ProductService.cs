


using Business.Products.DTOS;
using Business.Products.Models;
using Business.Products.Repositories;
using Microsoft.Extensions.Logging;

namespace Business.Products.Persistence
{
    

    public class ProductService : IProductService
    {


        private readonly IProductRepository _productRepository;


        public ProductService(IProductRepository productRepository)
        {
          

            _productRepository = productRepository;
        }

        public Task<ProductDTO> AddProduct(ProductModel product)
        {
            return _productRepository.AddProduct(product);
        }

        public Task<bool> RemoveProduct(long productId)
        {
            return _productRepository.RemoveProduct(productId);
        }

        public Task<List<ProductDTO>> SearchProduct(SearchProduct searchProduct)
        {
            return _productRepository.SearchProduct(searchProduct);
        }

        public Task<ProductDTO> UpdateProduct(ProductModel product)
        {
            return _productRepository.UpdateProduct(product);
        }
    }
}
