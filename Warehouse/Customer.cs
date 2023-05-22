using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    [Table("Customer")]
    public partial class Customer
    {
        public Customer()
        {
            this.Export_Quantity = new HashSet<Export_Quantity>();
            this.Permetion_Export = new HashSet<Permetion_Export>();
        }


        [Key]
        public string Customer_Email { get; set; }
        public string Customer_Name { get; set; }
        public Nullable<int> Customer_Phone { get; set; }
        public int Customer_Mobile { get; set; }

        
        public string Customer_Website { get; set; }
        public string Customer_Fax { get; set; }
        public virtual ICollection<Export_Quantity> Export_Quantity { get; set; }
        public virtual ICollection<Permetion_Export> Permetion_Export { get; set; }


    }
}
