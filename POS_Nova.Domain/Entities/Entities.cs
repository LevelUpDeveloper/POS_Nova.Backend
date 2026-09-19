
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Nova.Domain.Entities
{
    [Table("Product", Schema = "Inventory")]
    public class Product
    {
        public int id { get; private set; }
        public string code { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int CategoryId { get; private set; }
        public int ProviderId { get; private set; }
        public int Stock { get; private set; }
        public decimal SellPrice { get; private set; }
        public string ImageUrl { get; private set; }
    }
}
