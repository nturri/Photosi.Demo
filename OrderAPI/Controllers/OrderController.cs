using Business.Orders.DTOS;
using Business.Orders.Models;
using Business.Orders.Persistence;
using Microsoft.AspNetCore.Mvc;

using System.Net;

namespace Order.Api
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {

             

        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {

            _orderService = orderService;
        }



        [HttpPost, Route("SaveOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<long>> SaveOrder(  OrderModel OrderModel)
        {

            return await _orderService.SaveOrder(OrderModel);

        }


      

        [HttpPut, Route("ModifyOrder")]

        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<long> Modify(OrderModel OrderModel)
        {


            return await _orderService.ModifyOrder (OrderModel);

        }

        [HttpPost, Route("SearchOrderByUserId")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<List<OrderDTO>> SearchOrderByUserId(long userID)
        {


            return await _orderService.SearchOrderByUserId (userID);

        }



    }
}
