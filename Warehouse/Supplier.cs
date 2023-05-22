using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    public partial class Supplier
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Supplier()
        {
            this.Import_Quantity = new HashSet<Import_Quantity>();
            this.Permetion_Import = new HashSet<Permetion_Import>();
        }

        [Key]
        public string Supplier_Email { get; set; }
        public string Supplier_Name { get; set; }
        public Nullable <int>Supplier_phone { get; set; }
        public int Supplier_Mobile { get; set; }
      

        public string Supplier_Website { get; set; }
        public string Supplier_Fax { get; set; }
        public virtual ICollection<Import_Quantity> Import_Quantity { get; set; }
        public virtual ICollection<Permetion_Import> Permetion_Import { get; set; }
    }
}
