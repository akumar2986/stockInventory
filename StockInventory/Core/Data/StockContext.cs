using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stock.Web.Entities;

namespace Stock.Web.Data
{
    public class StockContext : IdentityDbContext<ApplicationUser>
    {
        public StockContext(DbContextOptions options) : base(options) {}
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Variety> Varieties { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; } 
    }
}
