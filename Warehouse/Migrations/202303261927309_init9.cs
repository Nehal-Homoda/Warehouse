namespace Warehouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Import_Quantity", "Supplier_Supplier_Id", "dbo.Suppliers");
            DropForeignKey("dbo.Permetion_Import", "Supplier_Supplier_Id", "dbo.Suppliers");
            DropIndex("dbo.Import_Quantity", new[] { "Supplier_Supplier_Id" });
            DropIndex("dbo.Permetion_Import", new[] { "Supplier_Supplier_Id" });
            RenameColumn(table: "dbo.Import_Quantity", name: "Supplier_Supplier_Id", newName: "Supplier_Supplier_Email");
            RenameColumn(table: "dbo.Permetion_Import", name: "Supplier_Supplier_Id", newName: "Supplier_Supplier_Email");
            DropPrimaryKey("dbo.Suppliers");
            AlterColumn("dbo.Import_Quantity", "Supplier_Supplier_Email", c => c.String(maxLength: 128));
            AlterColumn("dbo.Permetion_Import", "Supplier_Supplier_Email", c => c.String(maxLength: 128));
            AlterColumn("dbo.Suppliers", "Supplier_phone", c => c.Int());
            AlterColumn("dbo.Suppliers", "Supplier_Email", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Suppliers", "Supplier_Email");
            CreateIndex("dbo.Import_Quantity", "Supplier_Supplier_Email");
            CreateIndex("dbo.Permetion_Import", "Supplier_Supplier_Email");
            AddForeignKey("dbo.Import_Quantity", "Supplier_Supplier_Email", "dbo.Suppliers", "Supplier_Email");
            AddForeignKey("dbo.Permetion_Import", "Supplier_Supplier_Email", "dbo.Suppliers", "Supplier_Email");
            DropColumn("dbo.Suppliers", "Supplier_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Suppliers", "Supplier_Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Permetion_Import", "Supplier_Supplier_Email", "dbo.Suppliers");
            DropForeignKey("dbo.Import_Quantity", "Supplier_Supplier_Email", "dbo.Suppliers");
            DropIndex("dbo.Permetion_Import", new[] { "Supplier_Supplier_Email" });
            DropIndex("dbo.Import_Quantity", new[] { "Supplier_Supplier_Email" });
            DropPrimaryKey("dbo.Suppliers");
            AlterColumn("dbo.Suppliers", "Supplier_Email", c => c.String());
            AlterColumn("dbo.Suppliers", "Supplier_phone", c => c.Int(nullable: false));
            AlterColumn("dbo.Permetion_Import", "Supplier_Supplier_Email", c => c.Int());
            AlterColumn("dbo.Import_Quantity", "Supplier_Supplier_Email", c => c.Int());
            AddPrimaryKey("dbo.Suppliers", "Supplier_Id");
            RenameColumn(table: "dbo.Permetion_Import", name: "Supplier_Supplier_Email", newName: "Supplier_Supplier_Id");
            RenameColumn(table: "dbo.Import_Quantity", name: "Supplier_Supplier_Email", newName: "Supplier_Supplier_Id");
            CreateIndex("dbo.Permetion_Import", "Supplier_Supplier_Id");
            CreateIndex("dbo.Import_Quantity", "Supplier_Supplier_Id");
            AddForeignKey("dbo.Permetion_Import", "Supplier_Supplier_Id", "dbo.Suppliers", "Supplier_Id");
            AddForeignKey("dbo.Import_Quantity", "Supplier_Supplier_Id", "dbo.Suppliers", "Supplier_Id");
        }
    }
}
