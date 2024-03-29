﻿using Stock.Web.Data;
using Stock.Web.Entities;
using System.Collections.Generic;

namespace Stock.Web.Data.Repository
{
    public interface IBatchRepository
    {
        IEnumerable<Batch> GetAll();
        Batch Get(long id);
        void Add(Batch entity);
        void Update(Batch updateentity, Batch entity);
        void Delete(long id);
        List<Batch> GetAllBatches();
        Batch GetAllBatchesById(long id);
        int AddUpdateBatchStock(int? batchid, int quantity, string productName, string varietyName);
    }
}
