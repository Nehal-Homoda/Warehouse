using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    public partial class item_WareHouse
    {
        [Key]
        [Column(Order = 1)]
         public string WH_Name { get; set; }
        [Key]
        [Column(Order = 2)]
        public int I_Code { get; set; }
        public Nullable<int> Quantity { get; set; }

        public virtual Item Item { get; set; }
        public virtual WareHouse WareHouse { get; set; }
    }
}
