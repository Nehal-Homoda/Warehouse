namespace Warehouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Export_Quantity", "Customer_Customer_Id", "dbo.Customer");
            DropForeignKey("dbo.Permetion_Export", "Customer_Customer_Id", "dbo.Customer");
            DropIndex("dbo.Export_Quantity", new[] { "Customer_Customer_Id" });
            DropIndex("dbo.Permetion_Export", new[] { "Customer_Customer_Id" });
            DropColumn("dbo.Export_Quantity", "Customer_Email");
            DropColumn("dbo.Permetion_Export", "Customer_Email");
            RenameColumn(table: "dbo.Export_Quantity", name: "Customer_Customer_Id", newName: "Customer_Email");
            RenameColumn(table: "dbo.Permetion_Export", name: "Customer_Customer_Id", newName: "Customer_Email");
            DropPrimaryKey("dbo.Customer");
            AlterColumn("dbo.Customer", "Customer_Email", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Export_Quantity", "Customer_Email", c => c.String(maxLength: 128));
            AlterColumn("dbo.Export_Quantity", "Customer_Email", c => c.String(maxLength: 128));
            AlterColumn("dbo.Permetion_Export", "Customer_Email", c => c.String(maxLength: 128));
            AlterColumn("dbo.Permetion_Export", "Customer_Email", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Customer", "Customer_Email");
            CreateIndex("dbo.Export_Quantity", "Customer_Email");
            CreateIndex("dbo.Permetion_Export", "Customer_Email");
            AddForeignKey("dbo.Export_Quantity", "Customer_Email", "dbo.Customer", "Customer_Email");
            AddForeignKey("dbo.Permetion_Export", "Customer_Email", "dbo.Customer", "Customer_Email");
            DropColumn("dbo.Customer", "Customer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "Customer_Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Permetion_Export", "Customer_Email", "dbo.Customer");
            DropForeignKey("dbo.Export_Quantity", "Customer_Email", "dbo.Customer");
            DropIndex("dbo.Permetion_Export", new[] { "Customer_Email" });
            DropIndex("dbo.Export_Quantity", new[] { "Customer_Email" });
            DropPrimaryKey("dbo.Customer");
            AlterColumn("dbo.Permetion_Export", "Customer_Email", c => c.Int());
            AlterColumn("dbo.Permetion_Export", "Customer_Email", c => c.String());
            AlterColumn("dbo.Export_Quantity", "Customer_Email", c => c.Int());
            AlterColumn("dbo.Export_Quantity", "Customer_Email", c => c.String());
            AlterColumn("dbo.Customer", "Customer_Email", c => c.String());
            AddPrimaryKey("dbo.Customer", "Customer_Id");
            RenameColumn(table: "dbo.Permetion_Export", name: "Customer_Email", newName: "Customer_Customer_Id");
            RenameColumn(table: "dbo.Export_Quantity", name: "Customer_Email", newName: "Customer_Customer_Id");
            AddColumn("dbo.Permetion_Export", "Customer_Email", c => c.String());
            AddColumn("dbo.Export_Quantity", "Customer_Email", c => c.String());
            CreateIndex("dbo.Permetion_Export", "Customer_Customer_Id");
            CreateIndex("dbo.Export_Quantity", "Customer_Customer_Id");
            AddForeignKey("dbo.Permetion_Export", "Customer_Customer_Id", "dbo.Customer", "Customer_Id");
            AddForeignKey("dbo.Export_Quantity", "Customer_Customer_Id", "dbo.Customer", "Customer_Id");
        }
    }
}
