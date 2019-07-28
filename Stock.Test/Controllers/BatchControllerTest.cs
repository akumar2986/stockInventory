using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Stock.Web.Core.BAL;
using Stock.Web.Controllers;
using Stock.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Stock.Web.Utility;

namespace Stock.Test.Controllers
{
    [TestClass]
    public class BatchControllerTest
    {
        private Mock<IBatchBll> _batchbllMock;
        private Mock<ILog> _loggerMock;
        BatchController objController;
        List<BatchModel> listBatches;

        [TestInitialize]
        public void Initialize()
        {
            _batchbllMock = new Mock<IBatchBll>();
            _loggerMock = new Mock<ILog>();
            objController = new BatchController(_batchbllMock.Object, _loggerMock.Object);
            listBatches = new List<BatchModel>() {
             new BatchModel() { BatchId = 1, Name = "US",Quantity=10,Variety="Rasberry" },
                         new BatchModel() { BatchId = 2, Name = "US",Quantity=10,Variety="Rasberry2" },
                          new BatchModel() { BatchId = 3, Name = "US",Quantity=10,Variety="Rasberry3" }
            };
        }



        [TestMethod]
        public void Batch_Get_All()
        {
            //Arrange
            _batchbllMock.Setup(x => x.GetAllBatchStocks()).Returns(listBatches);

            //Act
            var result = ((objController.Index() as ViewResult).Model) as List<BatchModel>;

            //Assert
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual("US", result[0].Name);
            Assert.AreEqual("India", result[1].Name);
            Assert.AreEqual("Russia", result[2].Name);

        }

        [TestMethod]
        public void Valid_Batch_Create()
        {
            //Arrange
            BatchModel c = new BatchModel() { Name = "test1", Variety = "variety", Quantity = 10 };

            //Act
            var result = (RedirectToRouteResult)objController.Create(c);

            //Assert 
            _batchbllMock.Verify(m => m.AddUpdateBatchStock(c), Times.Once);
            Assert.AreEqual("Index", result.RouteValues["action"]);

        }

        [TestMethod]
        public void Invalid_Batch_Create()
        {
            // Arrange
            BatchModel c = new BatchModel() { Name = "" };
            objController.ModelState.AddModelError("Error", "Something went wrong");

            //Act
            var result = (ViewResult)objController.Create(c);

            //Assert
            _batchbllMock.Verify(m => m.AddUpdateBatchStock(c), Times.Never);
            Assert.AreEqual("", result.ViewName);
        }

    }
}
