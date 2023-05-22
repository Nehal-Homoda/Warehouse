using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
   public partial class Import_Quantity
    {
        [Key]
        [Column(Order = 1)]
        public int Permetion_Num_I { get; set; }
        [Key]
        [Column(Order = 2)]
        public int I_Code { get; set; }
        public string Supp_Email { get; set; }
        public string WH_Name { get; set; }
        public int In_Quantity { get; set; }
        public Nullable<System.DateTime> Prod_Date { get; set; }
        public Nullable<System.DateTime> Expi_Date { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual Item Item { get; set; }
        public virtual Permetion_Import Permetion_Import { get; set; }
        public virtual WareHouse WareHouse { get; set; }
    }
}
