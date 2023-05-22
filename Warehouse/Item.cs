using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Warehouse
{
    public partial class Item
    {
        public Item()
        {
            this.Export_Quantity = new HashSet<Export_Quantity>();
            this.Import_Quantity = new HashSet<Import_Quantity>();
            this.item_WareHouse = new HashSet<item_WareHouse>();
            this.Item_Measure = new HashSet<Item_Measure>();
            this.Permetion_Import = new HashSet<Permetion_Import>();
            this.Move_To = new HashSet<Move_To>();
            this.Permetion_Export = new HashSet<Permetion_Export>();
        }
        [Key]public int I_Code { get; set; }
        public string I_Name { get; set; }
        public Nullable<System.DateTime> Prod_Date { get; set; }
        public Nullable<System.DateTime> Expi_Date { get; set; }
        public virtual ICollection<Export_Quantity> Export_Quantity { get; set; }
        
        public virtual ICollection<Import_Quantity> Import_Quantity { get; set; }
        
        public virtual ICollection<item_WareHouse> item_WareHouse { get; set; }
        public virtual ICollection<Item_Measure> Item_Measure { get; set; }
        public virtual ICollection<Permetion_Import> Permetion_Import { get; set; }
        public virtual ICollection<Move_To> Move_To { get; set; }
        public virtual ICollection<Permetion_Export> Permetion_Export { get; set; }
    }
}
