﻿using Stock.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Web.Core.BAL
{
   public interface IStockBll
    {
        //To View all employees details    
        IEnumerable<StockModel> GetAllProductStocks();

        //To Add new stock record    
         void AddProductStock(StockModel employee);

        //To Update the records of a particluar batch/stock  
         void UpdateProductStock(StockModel stockModel);

        //Get the details of a particular stock  
         StockModel GetStockData(int? id);

        //To Delete the record on a particular stock  
         void DeleteProductStock(int? id);     
    }

   
}
