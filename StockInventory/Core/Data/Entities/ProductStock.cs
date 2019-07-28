using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stock.Web.Entities
{
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

}
