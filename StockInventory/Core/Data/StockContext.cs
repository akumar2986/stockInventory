using Microsoft.EntityFrameworkCore;
using Stock.Web.Entities;

namespace Stock.Web.Data
{
    public class StockContext : DbContext
    {
        public StockContext(DbContextOptions<StockContext> options) : base(options) {}
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Variety> Varieties { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; } 
    }
}
