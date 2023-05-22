using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    public partial class Permetion_Import
    {
        public Permetion_Import()
        {
            this.Import_Quantity = new HashSet<Import_Quantity>();
        }
        [Key] public int Permetion_Num_Imp { get; set; }
        public int I_Code { get; set; }
       
        public string WH_Name { get; set; }
        public virtual Supplier Supplier { get; set; }
        public Nullable< DateTime> Permetion_Date_I { get; set; }
        public string Supp_Email { get; set; }

        public virtual ICollection<Import_Quantity> Import_Quantity { get; set; }
        public virtual Item Item { get; set; }
        
        public virtual WareHouse WareHouse { get; set; }
    }
}
