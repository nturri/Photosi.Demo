using AutoMapper;
using Business.Orders.DTOS;
using Business.Orders.Models;
using Business.Orders.Persistence;
using Data.Order.Repositories;
using Data.Orders.Entities;
using Data.Orders.Persistence;
using Microsoft.Extensions.Logging;
 using Microsoft.EntityFrameworkCore;

namespace Business.Orders.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        

       private readonly ILogger<OrderRepository> _logger;

       public OrderRepository(MySqlDbContext context, ILogger<OrderRepository> logger) : base(context)
        {
                _logger = logger;
        }

        private Order ToOrder(OrderModel order)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrderModel, Order>();
                cfg.CreateMap<OrderDetailModel, OrderDetail>();
            });




            //Using automapper
            var mapper = new Mapper(config);
            var _order = mapper.Map<Order>(order);




            return _order;
        }

        private OrderDTO ToOrder(Order order)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDTO>();
                cfg.CreateMap<OrderDetail, OrderDetailDTO>();
            });




            //Using automapper
            var mapper = new Mapper(config);
            var _order = mapper.Map<OrderDTO>(order);




            return _order;
        }

        public async Task<long> ModifyOrder(OrderModel orderModel)
        {
      

            var order = ToOrder(orderModel);


            var entity = _context.Orders.Where(o => o.OrderId == orderModel.OrderId).FirstOrDefault();


            entity.AddressId = order.AddressId;
            entity.OrderDetail = order.OrderDetail;

            foreach (var detail in entity.OrderDetail)
            {
                detail.OrderId = entity.OrderId;
            }


            await _context.SaveChangesAsync();


            return entity.OrderId;

        }

        public async Task<bool> RemoveOrder(long orderId)
        {
            var order =  _context.Orders.Where(o => o.OrderId == orderId).FirstOrDefault();


            if (order == null)
                throw new Exception("attenzione: ordine non trovato");


            _context.Remove(order);

            await _context.SaveChangesAsync();

            return true;



        }

        public async Task<long> SaveOrder(OrderModel orderModel)
        {
           

                       


            var entity = ToOrder(orderModel);

      

            foreach (var detail in entity.OrderDetail)
            {

              
                detail.OrderId = entity.OrderId;
             
            }



            _context.Orders.Add(entity);


            await _context.SaveChangesAsync();


            return entity.OrderId;


        }

        public async Task<List<OrderDTO>> SearchOrderByUserId(long userId)
        {
            var ordini = await _context.Orders.Where(o => o.UserId == userId).ToListAsync();

            return ordini.Select(p => ToOrder(p)).ToList();

         

        }

        public async Task<List<OrderDTO>> SearchOrderByUserName(string userName)
        {
            var ordini = await _context.Orders.Where(o => o.UserName == userName).ToListAsync();

            return ordini.Select(p => ToOrder(p)).ToList();

            
        }
    }
}
