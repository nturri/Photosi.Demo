

using Business.Orders.DTOS;
using Business.Orders.Models;

namespace Business.Orders.Persistence
{
    public interface IOrderService
    {

        Task<long> SaveOrder(OrderModel order);

        Task<long> ModifyOrder(OrderModel order);

        Task<bool> RemoveOrder(long orderId);

        Task<List<OrderDTO>> SearchOrderByUserName(string userName);

        Task<List<OrderDTO>> SearchOrderByUserId(long userId);
    }
}
