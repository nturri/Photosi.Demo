using NUnit.Framework;





using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Reflection;


using Business.Products.Persistence;
using CsvHelper;
using Business.Products.Models;
using Business.Products.Repositories;
using Data.Products.Persistence;
using Product.API;

namespace Photosi.Test
{

    public class TestProducts
    {

        private readonly IProductService _productService;


        private readonly ProductController _productController;

        string pathCsv;


        public void OneTimeSetUp()
        {
            var testDllName = Assembly.GetAssembly(GetType())
                                      .GetName()
                                      .Name;
            var configName = testDllName + ".dll.config";
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", configName);
        }




       
        public TestProducts()
        {
            OneTimeSetUp();

            pathCsv = ConfigurationManager.AppSettings["pathCsv"];


            var serviceProvider = new ServiceCollection()
             .AddLogging()
             .AddSingleton<IProductRepository, ProductRepository>()
             .AddSingleton<IProductService, ProductService>()
             
       

             .AddDbContext< MySqlDbContext > (options => options.UseInMemoryDatabase(databaseName: "PhotoSi"))
           

             .BuildServiceProvider();


              _productService = serviceProvider.GetService<IProductService>();

              _productController = new ProductController(_productService);

        }


        [Test]
        public async Task products()
        {

            int count = 0;
            int numeroProdotti = 0;

            using (var reader = new StreamReader(pathCsv + "\\prodotti.csv"))
            using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.CreateSpecificCulture("it-IT")))
            {
                var records = csv.GetRecords<ProductModel>().ToList();

                numeroProdotti = records.Count;

                foreach (var p in records)
                {
                   
                    var pAdd = await _productController.Add(p);


                    if (pAdd != null)
                        count++;
                    else
                        Assert.IsTrue(false);

                    ProductModel product = new ProductModel();
                   
                   
                    product.Name = pAdd.Name;
                    product.Price = pAdd.Price + 1;
                    product.Category = pAdd.Category;
                    product.Id = pAdd.Id;

                    var pMod = await _productController.Update(product);


                    if (pMod.Price != product.Price)
                        Assert.IsTrue(false);

                    /**fare update*/


                }


                SearchProduct search = new SearchProduct();

                search.Name = "";
                search.Category = "";
                

                var listaFinale = await _productService.SearchProduct(search);

                if (listaFinale.Count != numeroProdotti)
                    Assert.IsTrue(false);
                else

                    Assert.IsTrue(true);
            }



        }





    }

    }
