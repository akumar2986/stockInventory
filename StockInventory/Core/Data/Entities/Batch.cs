using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stock.Web.Entities
{
    
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
