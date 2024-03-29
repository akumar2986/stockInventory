using Stock.Web.Data;
using Stock.Web.Data.Repository;
using Stock.Web;
using System;
using System.Collections.Generic;
using Stock.Web.Models;
using Stock.Web.Entities;

namespace Stock.Web.Core.BAL
{
    public class StockBll : IStockBll
    {        
        private readonly IDataRepository<ProductStock> _productStockRepository;
        public StockBll(StockContext context, IDataRepository<ProductStock> dataRepository)
        {
            _productStockRepository = dataRepository;
        }

        //To View all employees details    
        public IEnumerable<StockModel> GetAllProductStocks()
        {
            try
            {
                List<StockModel> lststocks = new List<StockModel>();

                var stocks = _productStockRepository.GetAll();
                foreach (var data in stocks)
                {
                    StockModel stockModel = new StockModel();
                    stockModel.StockId = data.ProductStockID;
                    stockModel.Name = data.Product.ProductName;
                    stockModel.Quantity = data.Quantity;
                    stockModel.Variety = data.Variety.Name;
                    lststocks.Add(stockModel);
                }
                return lststocks;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //To Add new stock record    
        public void AddProductStock(StockModel stock)
        {

        }

        //To Update the records of a particluar batch/stock  
        public void UpdateProductStock(StockModel stock)
        {

        }

        //Get the details of a particular stock  
        public StockModel GetStockData(int? id)
        {
            StockModel stockModel = new StockModel();
            return stockModel;
        }

        //To Delete the record on a particular stock  
        public void DeleteProductStock(int? id)
        {

        }
    }
}