namespace Warehouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Import_Quantity", "Supplier_Supplier_Name", "dbo.Suppliers");
            DropForeignKey("dbo.Permetion_Import", "Supplier_Supplier_Name", "dbo.Suppliers");
            RenameColumn(table: "dbo.Import_Quantity", name: "Supplier_Supplier_Name", newName: "Supplier_Supplier_Email");
            RenameColumn(table: "dbo.Permetion_Import", name: "Supplier_Supplier_Name", newName: "Supplier_Supplier_Email");
            RenameIndex(table: "dbo.Import_Quantity", name: "IX_Supplier_Supplier_Name", newName: "IX_Supplier_Supplier_Email");
            RenameIndex(table: "dbo.Permetion_Import", name: "IX_Supplier_Supplier_Name", newName: "IX_Supplier_Supplier_Email");
            DropPrimaryKey("dbo.Suppliers");
            AlterColumn("dbo.Suppliers", "Supplier_Name", c => c.String());
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
            AlterColumn("dbo.Suppliers", "Supplier_Email", c => c.String());
            AlterColumn("dbo.Suppliers", "Supplier_Name", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Suppliers", "Supplier_Name");
            RenameIndex(table: "dbo.Permetion_Import", name: "IX_Supplier_Supplier_Email", newName: "IX_Supplier_Supplier_Name");
            RenameIndex(table: "dbo.Import_Quantity", name: "IX_Supplier_Supplier_Email", newName: "IX_Supplier_Supplier_Name");
            RenameColumn(table: "dbo.Permetion_Import", name: "Supplier_Supplier_Email", newName: "Supplier_Supplier_Name");
            RenameColumn(table: "dbo.Import_Quantity", name: "Supplier_Supplier_Email", newName: "Supplier_Supplier_Name");
            AddForeignKey("dbo.Permetion_Import", "Supplier_Supplier_Name", "dbo.Suppliers", "Supplier_Name");
            AddForeignKey("dbo.Import_Quantity", "Supplier_Supplier_Name", "dbo.Suppliers", "Supplier_Name");
        }
    }
}
