using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Stock.Web.Core.BAL;
using Stock.Web.Data.Repository;
using Stock.Web.Entities;
using Stock.Web.Models;

namespace SampleArch.Test.Services
{
    [TestClass]
    public class BatchServiceTest
    {
        private Mock<IBatchRepository> _mockRepository;
        private IBatchBll _service;        
        List<Batch> batches;

        List<BatchModel> batchModels;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IBatchRepository>();
            _service = new BatchBll(_mockRepository.Object);
            batchModels = new List<BatchModel>() {
             new BatchModel() { BatchId = 1, Name = "US",Quantity=10,Variety="Rasberry" },
                         new BatchModel() { BatchId = 2, Name = "US",Quantity=10,Variety="Rasberry2" },
                          new BatchModel() { BatchId = 3, Name = "US",Quantity=10,Variety="Rasberry3" }
            };
        }

        [TestMethod]
        public void Batch_Get_All()
        {
            //Arrange
            _mockRepository.Setup(x => x.GetAllBatches()).Returns(batches);

            //Act
            List<BatchModel> results = _service.GetAllBatchStocks() as List<BatchModel>;

            //Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(3, results.Count);
        }


        [TestMethod]
        public void Can_Add_BatchesAndStock()
        {
            //Arrange
            int Id = 1;
            BatchModel batch = new BatchModel() { Name = "Product", Quantity = 20, Variety = "Variety", BatchId = 0 };
            _mockRepository.Setup(m => m.AddUpdateBatchStock(batch.BatchId, batch.Quantity, batch.Name, batch.Variety)).Returns((int e) =>
               {
                   e = Id;
                   return e;
               });


            //Act
            _service.AddUpdateBatchStock(batch);

            //Assert
            Assert.AreEqual("Product", batch.Name);

        }
    }
}
