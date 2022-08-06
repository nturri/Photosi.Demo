


using Business.Products.DTOS;
using Business.Products.Models;

namespace Business.Products.Persistence
{
    

    public interface IProductRepository
    {
        Task<ProductDTO> AddProduct(ProductModel product);
      
        Task<ProductDTO> UpdateProduct(ProductModel product);

        Task<bool> RemoveProduct(long productId);
  
        Task<List<ProductDTO>> SearchProduct(SearchProduct name);

    }
}
