using Stock.Web.Data;
using Stock.Web.Data.Repository;
using Stock.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Web.Data.Repository
{
    public class ProductRepository : IDataRepository<Product>
    {
        readonly StockContext _stockContext;

        public ProductRepository(StockContext context)
        {
            _stockContext = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _stockContext.Products.ToList();
        }

        public Product Get(long id)
        {
            return _stockContext.Products.FirstOrDefault(e => e.ProductId == id);
        }

        public void Add(Product entity)
        {
            _stockContext.Products.Add(entity);
            _stockContext.SaveChanges();
        }

        public void Update(Product productStock, Product entity)
        {
            productStock.ProductName = entity.ProductName; 
            _stockContext.SaveChanges();
        }

        public void Delete(Product product)
        {
            _stockContext.Products.Remove(product);
            _stockContext.SaveChanges();
        }
    }
}
