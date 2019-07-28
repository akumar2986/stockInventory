using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stock.Web.Entities
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public ICollection<Batch> Batches { get; set; }
        public ICollection<ProductStock> ProductStocks { get; set; }
    }
}
