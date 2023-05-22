using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    public partial class Item_Measure
    {
        [Key]
        [Column(Order = 1)]
        public int I_Code { get; set; }
        [Key][Column(Order = 2)]
        public string Measure { get; set; }

        public virtual Item Item { get; set; }
    }
}
