using Stock.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Web.Core.BAL
{
    public interface IBatchBll
    {
        //To View all product details    
        IEnumerable<BatchModel> GetAllBatchStocks();

        //To Add new stock record    
        void AddUpdateBatchStock(BatchModel batchModel);

        //To Update the records of a particluar batch/stock  
        //void UpdateBatchStock(BatchModel batchModel);

        //Get the details of a particular stock  
        BatchModel GetBatchData(long? id);

        //To Delete the record on a particular stock  
        void DeleteBatchStock(long id);

    }
}
