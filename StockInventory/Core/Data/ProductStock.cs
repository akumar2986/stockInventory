using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stock.Web.Data
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public ICollection<Batch> Batches { get; set; }
        public ICollection<ProductStock> ProductStocks { get; set; }
    }

    public class ProductStock
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductStockID { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int VarietyID { get; set; } 
        public Variety Variety { get; set; }
    }

    public class Batch
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BatchId { get; set; }

        public int Quantity { get; set; }

        //foreign key with product table
        public int ProductId { get; set; }
        public Product Product { get; set; }

        //foreign key with variety table
        public int VarietyId { get; set; }
        public Variety Variety { get; set; }

    }


}
