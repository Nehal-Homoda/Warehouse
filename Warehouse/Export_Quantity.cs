using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    public partial class Export_Quantity
    {
        [Key]
        [Column(Order = 1)]
        public int Permetion_Num_Exp { get; set; }
        [Key]
        [Column(Order = 2)]
        public int I_Code { get; set; }
        public string Customer_Email { get; set; }
        public string WH_Name { get; set; }
        public int Out_Quantity { get; set; }
        public Nullable <DateTime> Prod_Date { get; set; }
        public Nullable <DateTime> Expi_Date { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Item Item { get; set; }
        public virtual Permetion_Export Permetion_Export { get; set; }
        public virtual WareHouse WareHouse { get; set; }
    }
}
