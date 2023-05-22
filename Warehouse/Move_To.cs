using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    public partial class Move_To
    {
        [Key]
        [Column(Order = 1)]
        public int I_Code { get; set; }
        [Key]
        [Column(Order = 2)]
        public string FromWH_Nm { get; set; }
        [Key]
        [Column(Order = 3)]
        public string ToWH_Nm { get; set; }
        public Nullable<int> Quantity { get; set; }
        public  DateTime Move_Date { get; set; }
        public DateTime Production_Date { get; set; }
        public Nullable< DateTime> Expire_Date { get; set; }

        public virtual Item Item { get; set; }
        public virtual WareHouse WareHouse { get; set; }
        public virtual WareHouse WareHouse1 { get; set; }
    }
}
