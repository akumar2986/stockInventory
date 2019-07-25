using Microsoft.EntityFrameworkCore;
using Stock.Web.Data;
using Stock.Web.Data.Repository;
using Stock.Web.Models;
using System;  
using System.Collections.Generic;  
using System.Data;  
using System.Data.SqlClient;  
using System.Linq;  
using System.Threading.Tasks;  
  
namespace Stock.Web.Core.BAL
{  
    public class BatchBll:IBatchBll
    {

        private readonly IBatchRepository _batchRepository;

        public BatchBll(StockContext context, IBatchRepository dataRepository,
            IDataRepository<Product> productRepository)
        {
            _batchRepository = dataRepository;
        }


        //To View all batch details    
        public IEnumerable<BatchModel> GetAllBatchStocks()
        {
            List<BatchModel> lstBatchs = new List<BatchModel>();

            var batchstock = _batchRepository.GetAllBatches();
            foreach (var data in batchstock)
            {
                BatchModel batchModel = new BatchModel();
                batchModel.BatchId = data.BatchId;
                batchModel.Name = data.Product.ProductName;
                batchModel.Quantity = data.Quantity;
                batchModel.Variety = data.Variety.Name;
                lstBatchs.Add(batchModel);
            }
            return lstBatchs;
        }

        //To Add new Batch record    
        public void AddUpdateBatchStock(BatchModel batchmodel)
        {
            try
            {
                _batchRepository.AddUpdateBatchStock(batchmodel.BatchId, batchmodel.Quantity, batchmodel.Name, batchmodel.Variety);
            }
            catch (Exception ex)
            {

            }
        }


        //Get the details of a particular Batch  
        public BatchModel GetBatchData(long? id)
        {
            BatchModel batchModel = new BatchModel();
            var batchstock = _batchRepository.GetAllBatchesById(id.Value);

            if (batchstock != null)
            {

                batchModel.BatchId = batchstock.BatchId;
                batchModel.Name = batchstock.Product.ProductName;
                batchModel.Quantity = batchstock.Quantity;
                batchModel.Variety = batchstock.Variety.Name;
            }
            return batchModel;
        }
  
        //To Delete the record on a particular Batch  
        public void DeleteBatchStock(long id)  
        {
            _batchRepository.Delete(id);
        }        
    }  
}  