using Business.Orders.DTOS;
using Business.Orders.Models;
using Business.Orders.Persistence;
using Microsoft.AspNetCore.Mvc;

using System.Net;

namespace WebPhotosi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {


        private readonly ILogger<OrderController> _logger;

        private readonly IOrderRepository _orderRepository;
        public OrderController(ILogger<OrderController> logger, IOrderRepository orderRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
        }



        [HttpPost, Route("SaveOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> SaveOrder(  OrderModel OrderModel)
        {

            return await _orderRepository.SaveOrder(OrderModel);

        }


      

        [HttpPut, Route("ModifyOrder")]

        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<string> Modify(OrderModel OrderModel)
        {


            return await _orderRepository.ModifyOrder (OrderModel);

        }

        [HttpPost, Route("SearchOrderByUserId")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<List<OrderDTO>> SearchOrderByUserId(string userID)
        {


            return await _orderRepository.SearchOrderByUserId (userID);

        }



    }
}
