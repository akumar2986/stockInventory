using System.Collections.Generic;
using System.Linq;
using Stock.Web.Data.Repository;


namespace Stock.Web.Data.Repository
{
    public class ProductStockRepository : IDataRepository<ProductStock>
    {
        readonly StockContext _stockContext;

        public ProductStockRepository(StockContext context)
        {
            _stockContext = context;
        }

        public IEnumerable<ProductStock> GetAll()
        {
            var stocks =
            from pstock in _stockContext.ProductStocks
            join vty in _stockContext.Varieties on pstock.VarietyID equals vty.VarietyId
            join p in _stockContext.Products on pstock.ProductId equals p.ProductId
            select new ProductStock
            {
                ProductStockID = pstock.ProductStockID,
                Quantity = pstock.Quantity,
                Variety = vty,
                Product = p
            };
            return stocks;
            //return _stockContext.ProductStocks.ToList();
        }

        public ProductStock Get(long id)
        {
            return _stockContext.ProductStocks.FirstOrDefault(e => e.ProductStockID == id);
        }

        public void Add(ProductStock entity)
        {
            _stockContext.ProductStocks.Add(entity);
            _stockContext.SaveChanges();
        }

        public void Update(ProductStock productStock, ProductStock entity)
        {
            productStock.ProductId = entity.ProductId;
            productStock.Quantity = entity.Quantity;
            productStock.VarietyID = entity.VarietyID;
            _stockContext.SaveChanges();
        }

        public void Delete(ProductStock employee)
        {
            _stockContext.ProductStocks.Remove(employee);
            _stockContext.SaveChanges();
        }

    }   
}
