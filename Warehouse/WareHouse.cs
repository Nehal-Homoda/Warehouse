using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    public partial class WareHouse
    {
        public WareHouse()
        {
            this.Export_Quantity = new HashSet<Export_Quantity>();
            this.Import_Quantity = new HashSet<Import_Quantity>();
            this.item_WareHouse = new HashSet<item_WareHouse>();
            this.Move_To = new HashSet<Move_To>();
            this.Move_To1 = new HashSet<Move_To>();
            this.Permetion_Export = new HashSet<Permetion_Export>();
            this.Permetion_Import = new HashSet<Permetion_Import>();
        }
        [Key]public string WH_Name { get; set; }
        public string WH_Address { get; set; }
        public string WH_Manager { get; set; }
        public virtual ICollection<Export_Quantity> Export_Quantity { get; set; }
        public virtual ICollection<Import_Quantity> Import_Quantity { get; set; }
        public virtual ICollection<item_WareHouse> item_WareHouse { get; set; }
        public virtual ICollection<Move_To> Move_To { get; set; }
        public virtual ICollection<Move_To> Move_To1 { get; set; }
        public virtual ICollection<Permetion_Export> Permetion_Export { get; set; }
        public virtual ICollection<Permetion_Import> Permetion_Import { get; set; }
    }
}
