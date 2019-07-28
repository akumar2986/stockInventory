using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stock.Web.Entities;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using Stock.Web.Data.Repository;
using Stock.Web.Models;
using Stock.Web.Data;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Stock.Test.Repositories
{
    [TestClass]
    public class BatchRepositoryTest
    {
        private StockContext databaseContext;
        private IBatchRepository objRepo;
        private DbContextOptions<StockContext> _options;
        private IConfigurationRoot _configuration;

        [TestInitialize]
        public void Initialize()
        {
            string basepath = Directory.GetCurrentDirectory();
            var builder = new ConfigurationBuilder().SetBasePath(basepath).AddJsonFile("appsettings.json");
            _configuration = builder.Build();
            _options = new DbContextOptionsBuilder<StockContext>().UseSqlite
                (_configuration.GetConnectionString("DefaultConnection")).Options;
            databaseContext = new StockContext(_options);

            objRepo = new BatchRepository(databaseContext);
        }

        [TestMethod]
        public void Batch_Repository_Get_ALL()
        {
            //Act
            List<Batch> result = objRepo.GetAllBatches().ToList();

            //Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("FruitType", result[2].Variety);
            Assert.AreEqual("Product", result[1].Product);
            Assert.AreEqual(1, result[1].BatchId);
        }

        [TestMethod]
        public void Batch_Repository_Create()
        {
            //Act
            objRepo.AddUpdateBatchStock(1, 10, "test", "varietyType");
            var lst = objRepo.GetAllBatches().ToList();

            //Assert

            Assert.AreEqual(4, lst.Count);
            Assert.AreEqual("test", lst.Last().Product.ProductName);
        }
    }
}
