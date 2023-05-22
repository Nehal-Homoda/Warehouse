namespace Warehouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Import_Quantity", "Supplier_Supplier_Email", "dbo.Suppliers");
            DropForeignKey("dbo.Permetion_Import", "Supplier_Supplier_Email", "dbo.Suppliers");
            DropPrimaryKey("dbo.Suppliers");
            AlterColumn("dbo.Suppliers", "Supplier_Email", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Suppliers", "Supplier_Email");
            AddForeignKey("dbo.Import_Quantity", "Supplier_Supplier_Email", "dbo.Suppliers", "Supplier_Email");
            AddForeignKey("dbo.Permetion_Import", "Supplier_Supplier_Email", "dbo.Suppliers", "Supplier_Email");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Permetion_Import", "Supplier_Supplier_Email", "dbo.Suppliers");
            DropForeignKey("dbo.Import_Quantity", "Supplier_Supplier_Email", "dbo.Suppliers");
            DropPrimaryKey("dbo.Suppliers");
            AlterColumn("dbo.Suppliers", "Supplier_Email", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Suppliers", "Supplier_Email");
            AddForeignKey("dbo.Permetion_Import", "Supplier_Supplier_Email", "dbo.Suppliers", "Supplier_Email");
            AddForeignKey("dbo.Import_Quantity", "Supplier_Supplier_Email", "dbo.Suppliers", "Supplier_Email");
        }
    }
}
