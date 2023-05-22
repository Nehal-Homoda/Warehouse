using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    internal class Context : DbContext
    {
        public Context() : base(@"Data Source=DESKTOP-JVAMQIE;Initial Catalog=Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {

        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Export_Quantity> Export_Quantities { get; set; }
        public virtual DbSet<Import_Quantity> Import_Quantities { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Item_Measure> Item_Measures { get; set; }
        public virtual DbSet<item_WareHouse> Item_WareHouses { get; set; }
        public virtual DbSet<ItemsPer> ItemsPers { get; set; }
        public virtual DbSet<Move_To> Move_Tos { get; set; }
        public virtual DbSet<Permetion_Export> Permetion_Exports { get; set; }
        public virtual DbSet<Permetion_Import> Permetion_Imports { get; set; }
        public virtual DbSet<WareHouse>Warehouses { get; set; }
        


    }
}
