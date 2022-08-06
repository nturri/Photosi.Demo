using Business.Orders.DTOS;
using Business.Orders.Models;
using Business.Orders.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Orders.Service
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;


        public OrderService(IOrderRepository orderRepository)
        {

            _orderRepository = orderRepository;
        }


        public Task<long> ModifyOrder(OrderModel order)
        {
            return _orderRepository.ModifyOrder(order);
        }

        public Task<bool> RemoveOrder(long orderId)
        {
            return _orderRepository.RemoveOrder(orderId);
        }

        public Task<long> SaveOrder(OrderModel order)
        {
            return _orderRepository.SaveOrder(order);    
        }

        public Task<List<OrderDTO>> SearchOrderByUserId(long userId)
        {
            return _orderRepository.SearchOrderByUserId(userId);
        }

        public Task<List<OrderDTO>> SearchOrderByUserName(string userName)
        {
           return   _orderRepository.SearchOrderByUserName(userName);
        }
    }
}
