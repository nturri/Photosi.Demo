using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Data.Address.Persistence;

using Microsoft.EntityFrameworkCore;
using Business.Address.Persistence;
using Business.Address.Service;
using Business.Address.Repositories;
using NUnit.Framework;
using CsvHelper;
using Business.Address.Models;

namespace Photosi.Test.Address
{
    public class TestAddress
    {

        IAddressService _addressService;

        public void OneTimeSetUp()
        {
            var testDllName = Assembly.GetAssembly(GetType())
                                      .GetName()
                                      .Name;
            var configName = testDllName + ".dll.config";
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", configName);
        }

        string pathCsv;




        public TestAddress()
        {
            OneTimeSetUp();



            pathCsv = System.Configuration.ConfigurationManager.AppSettings["pathCsv"];


            var serviceProvider = new ServiceCollection()
             .AddLogging()



             .AddSingleton<IAddressRepository, AddressRepository>()
             .AddSingleton<IAddressService, AddressService>()



            .AddDbContext<MySqlDbContext>(options => options.UseInMemoryDatabase(databaseName: "PhotoSi"))



             .BuildServiceProvider();


            _addressService = serviceProvider.GetService<IAddressService>();



        }


        [Test]
        public async Task address()
        {/*
            SearchAddress searchAddress = new SearchAddress();

            searchAddress.Country = "italy";

            var oldList = await _addressRepository.SearchAddress(searchAddress);

            foreach (var address in oldList)
            {
                await _addressRepository.RemoveAddress(address.Id);
            }
            */


            int count = 0;
            int num = 0;

            using (var reader = new StreamReader(pathCsv + "\\address.csv"))
            using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.CreateSpecificCulture("it-IT")))
            {
                var records = csv.GetRecords<AddressModel>().ToList();

                num = records.Count;

                foreach (var a in records)
                {
                    a.Id = 0;


                    if (await _addressService.AddAddress(a) != null)

                        count++;



                }

                Assert.IsTrue(count == num);
            }


        }
    }

}