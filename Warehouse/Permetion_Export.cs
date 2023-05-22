using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    public partial class Permetion_Export
    {
        public Permetion_Export()
        {
            this.Export_Quantity = new HashSet<Export_Quantity>();
        }

        [Key]
        public int Permetion_Num_Exp { get; set; }
        [ForeignKey("Item")]
        public int I_Code { get; set; }
        public string WH_Name { get; set; }
        public string Customer_Email { get; set; }
        public Nullable< DateTime> Permetion_Date_Exp { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Export_Quantity> Export_Quantity { get; set; }
        public virtual Item Item { get; set; }
        public virtual WareHouse WareHouse { get; set; }
    }
}
