using Business.Products.DTOS;
using Business.Products.Models;
using Business.Products.Persistence;
using Microsoft.AspNetCore.Mvc;



using System.Net;

namespace WebPhotosi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {


        private readonly ILogger<ProductController> _logger;

        private readonly IProductRepository _productRepository;
        public ProductController(ILogger<ProductController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }



        [HttpPost, Route("AddProduct")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> Add(ProductModel productModel)
        {


            return await _productRepository.AddProduct(productModel);

        }


      

        [HttpPut, Route("UpdateProduct")]

        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ProductDTO> Update(ProductModel productModel)
        {


            return await _productRepository.UpdateProduct (productModel);

        }

        [HttpDelete, Route("RemoveProduct")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<bool> RemoveProduct(string productId)
        {


            return await _productRepository.RemoveProduct(productId);

        }

        [HttpPost, Route("SearchProduct")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<List<ProductDTO>> SearchProduct(SearchProduct search)
        {


            return await _productRepository.SearchProduct(search);

        }



    }
}
