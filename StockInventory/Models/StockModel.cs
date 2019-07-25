using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Web.Models
{
    public class StockModel
    {
        public int StockId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Variety { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
