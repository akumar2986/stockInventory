using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Stock.Web.Entities;

namespace Stock.Web.Data.Repository
{
    public class BatchRepository : IBatchRepository
    {
        readonly StockContext _context;

        public BatchRepository(StockContext context)
        {
            _context = context;
        }

        public IEnumerable<Batch> GetAll()
        {
            return _context.Batches.ToList();
        }

        public Batch Get(long id)
        {
            return _context.Batches.FirstOrDefault(e => e.BatchId == id);
        }

        public void Add(Batch entity)
        {
            _context.Batches.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Batch productStock, Batch entity)
        {
            productStock.ProductId = entity.ProductId;
            productStock.Quantity = entity.Quantity;
            productStock.VarietyId = entity.VarietyId;
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            Batch batch = _context.Batches.FirstOrDefault(i => i.BatchId == id);
            if (batch != null)
            {
                _context.Batches.Remove(batch);
                _context.SaveChanges();
                //  UpdateStock(productId, varietyid);   // to update stock during delete
            }
        }

        public List<Batch> GetAllBatches()
        {
            var batches =
                       from batch in _context.Batches
                       join vty in _context.Varieties on batch.VarietyId equals vty.VarietyId
                       join p in _context.Products on batch.ProductId equals p.ProductId
                       select new Batch
                       {
                           Quantity = batch.Quantity,
                           BatchId = batch.BatchId,
                           Variety = vty,
                           Product = p
                       };
            return batches.ToList();
        }

        public Batch GetAllBatchesById(long id)
        {
            try
            {
                var batchstock =
                           (from pstock in _context.Batches
                            join vty in _context.Varieties on pstock.VarietyId equals vty.VarietyId
                            join p in _context.Products on pstock.ProductId equals p.ProductId
                            where pstock.BatchId == id
                            select new Batch
                            {
                                BatchId = pstock.BatchId,
                                Quantity = pstock.Quantity,
                                Variety = vty,
                                Product = p
                            }).FirstOrDefault();
                return batchstock;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddUpdateBatchStock(int? batchid, int quantity, string productName, string varietyName)
        {
            try
            {
                Variety variety = _context.Varieties.FirstOrDefault(i => i.Name == varietyName);
                if (variety == null)
                {
                    variety = new Variety();
                    variety.Name = varietyName;
                    _context.Varieties.Add(variety);
                }

                Product product = _context.Products.FirstOrDefault(i => i.ProductName == productName);
                if (product == null)
                {
                    product = new Product();
                    product.ProductName = productName;
                    _context.Products.Add(product);
                }

                Batch batch = _context.Batches.FirstOrDefault(i => i.BatchId == batchid);
                if (batch == null)
                {
                    batch = new Batch();
                    batch.Product = product;
                    batch.Variety = variety;
                    batch.Quantity = quantity;
                    _context.Batches.Add(batch);
                }
                else
                {
                    batch.Product = product;
                    batch.Variety = variety;
                    batch.Quantity = quantity;
                    _context.Entry(batch).State = EntityState.Modified;
                }

                _context.SaveChanges();
                UpdateStock(batch.ProductId, batch.VarietyId);
                return batch.BatchId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void UpdateStock(int productid, int varietyid)
        {
            try
            {
                ProductStock productStock = _context.ProductStocks.FirstOrDefault(i => i.ProductId == productid && i.VarietyID == varietyid);

                var result = _context.Batches.Where(l => l.ProductId == productid && l.VarietyId == varietyid);
                var totalquantity = result.Sum(i => i.Quantity);


                if (productStock == null)
                    productStock = new ProductStock();


                productStock.ProductId = productid;
                productStock.VarietyID = varietyid;
                productStock.Quantity = totalquantity;

                if (productStock.ProductStockID == 0)
                    _context.ProductStocks.Add(productStock);
                else
                    _context.Entry(productStock).State = EntityState.Modified;

                _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
