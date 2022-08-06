using Business.Products.DTOS;
using Business.Products.Models;
using Business.Products.Persistence;
using Microsoft.AspNetCore.Mvc;



using System.Net;

namespace Product.API
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {


        

        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
           
            _productService = productService;
        }



        [HttpPost, Route("AddProduct")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ProductDTO> Add(ProductModel productModel)
        {


            return await _productService.AddProduct(productModel);

        }


      
        [HttpPut, Route("UpdateProduct")]

        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ProductDTO> Update(ProductModel productModel)
        {


            return await _productService.UpdateProduct (productModel);

        }

        [HttpDelete, Route("RemoveProduct")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<bool> RemoveProduct(long productId)
        {


            return await _productService.RemoveProduct(productId);

        }

        [HttpPost, Route("SearchProduct")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<List<ProductDTO>> SearchProduct(SearchProduct search)
        {


            return await _productService.SearchProduct(search);

        }



    }
}
