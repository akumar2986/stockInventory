//using Microsoft.EntityFrameworkCore;
//using Stock.Web.Entities;
//using System;
//using System.Collections.Generic;
//using System.Data.Common;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SampleArch.Test
//{
//    public class TestContext : DbContext
//    {
//        bool _created = false;
//        public TestContext(DbContextOptions<TestContext> options) : base(options) {
           
//            if (!_created)
//            {
//                _created = true;
//                Database.EnsureDeleted();
//                Database.EnsureCreated();
//            }
//        }
        
//        public DbSet<Product> Products { get; set; }
//        public DbSet<Variety> Varieties { get; set; }
//        public DbSet<Batch> Batches { get; set; }
//        public DbSet<ProductStock> ProductStocks { get; set; }

//        public void Seed(TestContext Context)
//        {
//            var listbatches = new List<Batch>() {
//             new Batch() { BatchId = 1, Quantity = 10,ProductId=2,VarietyId=3 },
//              new Batch() { BatchId = 2, Quantity = 30,ProductId=2,VarietyId=3 },
//               new Batch() { BatchId = 3, Quantity = 40,ProductId=3,VarietyId=3 }
//            };
//            Context.Batches.AddRange(listbatches);
//            Context.SaveChanges();
//        }
//    }
//}
