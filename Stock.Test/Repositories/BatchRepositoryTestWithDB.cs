using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using Stock.Web.Data.Repository;
using Stock.Web.Models;
using Stock.Web.Data;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Stock.Web.Entities;

namespace SampleArch.Test.Repositories
{
    [TestClass]
    public class BatchRepositoryTestWithDB
    {
        private readonly StockContext _databaseContext;
        BatchRepository objRepo;
        private DbContextOptions<StockContext> _options;
        private IConfiguration _configuration;
        
        [TestInitialize]
        public void Initialize()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            _configuration = builder.Build();
            _options = new DbContextOptionsBuilder<StockContext>().UseSqlite
                (_configuration.GetConnectionString("DefaultConnection")).Options;

            objRepo = new BatchRepository(_databaseContext);
      
        }

        [TestMethod]
        public void Batch_Repository_Get_ALL()
        {
            //Act
            List<Batch> result = objRepo.GetAllBatches().ToList();
            //Assert
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("FruitType", result[2].Variety.Name);
            Assert.AreEqual("Product", result[1].Product.ProductName);
            Assert.AreEqual(1, result[1].BatchId);
        }

        [TestMethod]
        public void Batch_Repository_Create()
        {
            //Arrange
            BatchModel c = new BatchModel() { Name = "UK" };

            //Act
            var result = objRepo.AddUpdateBatchStock(c.BatchId,c.Quantity,c.Name,c.Variety); 
            var lst = objRepo.GetAll().ToList();

            //Assert

            Assert.AreEqual(4, lst.Count);
            Assert.AreEqual("UK", lst.Last().Product.ProductName);
        }
    }
}
