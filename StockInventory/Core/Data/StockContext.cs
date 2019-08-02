using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stock.Web.Entities;

namespace Stock.Web.Data
{
    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    //{      
    //    public ApplicationDbContext(DbContextOptions options) : base(options)
    //    {

    //    }

    //    protected override void OnModelCreating(ModelBuilder builder)
    //    {
    //        base.OnModelCreating(builder);
    //        // Customize the ASP.NET Identity model and override the defaults if needed.
    //        // For example, you can rename the ASP.NET Identity table names and more.
    //        // Add your customizations after calling base.OnModelCreating(builder);
    //    }

    //    public DbSet<Product> Products { get; set; }
    //    public DbSet<Variety> Varieties { get; set; }
    //    public DbSet<Batch> Batches { get; set; }
    //    public DbSet<ProductStock> ProductStocks { get; set; }

    //}

    public class StockContext : IdentityDbContext<ApplicationUser>
    {
        public StockContext(DbContextOptions options) : base(options) {}
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Variety> Varieties { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; } 
    }
}
