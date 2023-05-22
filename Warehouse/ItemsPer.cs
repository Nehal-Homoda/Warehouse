using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    class ItemsPer
    {
        [Key]public string ProductName { get; set; }
        public int ItemQuantity { get; set; }
        public int oldQuantity { get; set; }
        public Nullable< DateTime> ProdDate { get; set; }
        public Nullable< DateTime> ExpiDate { get; set; }
        public string oldRecord { get; set; }
    }
}
