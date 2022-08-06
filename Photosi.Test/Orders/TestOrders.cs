using NUnit.Framework;




using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Reflection;


using Business.Orders.Persistence;

using Business.Orders.Service;
using Business.Orders.Repositories;
using Order.Api;
using Data.Orders.Persistence;
using Business.Orders.Models;

namespace Photosi.Test
{

    public class TestOrders
    {



      

        private readonly IOrderService _orderService;

        private readonly OrderController _orderController;


        string pathCsv;


        public void OneTimeSetUp()
        {
            var testDllName = Assembly.GetAssembly(GetType())
                                      .GetName()
                                      .Name;
            var configName = testDllName + ".dll.config";
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", configName);
        }




       
        public TestOrders()
        {
            OneTimeSetUp();

                      

            pathCsv = ConfigurationManager.AppSettings["pathCsv"];


            var serviceProvider = new ServiceCollection()
             .AddLogging()

             .AddSingleton<IOrderRepository, OrderRepository>()
             .AddSingleton<IOrderService, OrderService>()
             //.AddSingleton<MySqlDbContext, MySqlDbContext>()


            .AddDbContext<MySqlDbContext>(options => options.UseInMemoryDatabase(databaseName: "PhotoSi"))


              
             .BuildServiceProvider();


               serviceProvider.GetService<IOrderRepository>();

              _orderService = serviceProvider.GetService<IOrderService>();

            //  _orderController = new OrderController(_orderService);



        }



        [Test]
        public async Task orders()
        {

            OrderModel orderModel = new OrderModel();

            orderModel.AddressId = 1;
            orderModel.UserName = "nturri";
            orderModel.UserId = 1;

            OrderDetailModel orderDetailModel1 = new OrderDetailModel();

            orderDetailModel1.ProductId = 1;
            orderDetailModel1.Quantity = 1;

            orderModel.OrderDetail = new List<OrderDetailModel>(); 


            orderModel.OrderDetail.Add(orderDetailModel1);


             var orderId = await   _orderService.SaveOrder(orderModel);

             var orders = await _orderService.SearchOrderByUserId(1);

             var orderDto =   orders.Where(o => o.OrderId == orderId).FirstOrDefault();

 
             orderModel.OrderId = orderId;

            OrderDetailModel orderDetailModelMod = new OrderDetailModel();

            orderDetailModelMod.ProductId = orderDetailModel1.ProductId;
            orderDetailModelMod.Quantity = 2;
            orderDetailModelMod.OrderId = orderId;

            orderModel.OrderDetail.Clear();
            orderModel.OrderDetail.Add(orderDetailModelMod);


            var orderIdMod = await _orderService.ModifyOrder(orderModel);

            if (orderId != orderIdMod)
                Assert.IsTrue(false);


             Assert.IsNotNull(true);

    



        }


  




    }

    }
