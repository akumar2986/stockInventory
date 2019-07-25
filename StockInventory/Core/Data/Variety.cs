using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stock.Web.Data
{
    public class Variety
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VarietyId { get; set; }
        public string Name { get; set; }

        public ICollection<Batch> Batches { get; set; }
        public ICollection<ProductStock> ProductStocks { get; set; }
    }
}
