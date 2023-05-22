namespace Warehouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Export_Quantity",
                c => new
                    {
                        Permetion_Num_Exp = c.Int(nullable: false),
                        I_Code = c.Int(nullable: false),
                        Customer_Email = c.String(),
                        WH_Name = c.String(maxLength: 128),
                        Out_Quantity = c.Int(nullable: false),
                        Prod_Date = c.DateTime(nullable: false),
                        Expi_Date = c.DateTime(nullable: false),
                        Customer_Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.Permetion_Num_Exp, t.I_Code })
                .ForeignKey("dbo.Customer", t => t.Customer_Customer_Id)
                .ForeignKey("dbo.Items", t => t.I_Code, cascadeDelete: true)
                .ForeignKey("dbo.WareHouses", t => t.WH_Name)
                .ForeignKey("dbo.Permetion_Export", t => t.Permetion_Num_Exp, cascadeDelete: true)
                .Index(t => t.Permetion_Num_Exp)
                .Index(t => t.I_Code)
                .Index(t => t.WH_Name)
                .Index(t => t.Customer_Customer_Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        I_Code = c.Int(nullable: false, identity: true),
                        I_Name = c.String(),
                        Prod_Date = c.DateTime(nullable: false),
                        Expi_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.I_Code);
            
            CreateTable(
                "dbo.Import_Quantity",
                c => new
                    {
                        Permetion_Num_I = c.Int(nullable: false),
                        I_Code = c.Int(nullable: false),
                        Supp_Email = c.String(),
                        WH_Name = c.String(maxLength: 128),
                        In_Quantity = c.Int(nullable: false),
                        Prod_Date = c.DateTime(nullable: false),
                        Expi_Date = c.DateTime(nullable: false),
                        Permetion_Import_Permetion_Num_Imp = c.Int(),
                        Supplier_Supplier_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.Permetion_Num_I, t.I_Code })
                .ForeignKey("dbo.Items", t => t.I_Code, cascadeDelete: true)
                .ForeignKey("dbo.Permetion_Import", t => t.Permetion_Import_Permetion_Num_Imp)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_Supplier_Id)
                .ForeignKey("dbo.WareHouses", t => t.WH_Name)
                .Index(t => t.I_Code)
                .Index(t => t.WH_Name)
                .Index(t => t.Permetion_Import_Permetion_Num_Imp)
                .Index(t => t.Supplier_Supplier_Id);
            
            CreateTable(
                "dbo.Permetion_Import",
                c => new
                    {
                        Permetion_Num_Imp = c.Int(nullable: false, identity: true),
                        I_Code = c.Int(nullable: false),
                        Supp_Email = c.String(),
                        WH_Name = c.String(maxLength: 128),
                        Permetion_Date_I = c.DateTime(nullable: false),
                        Supplier_Supplier_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Permetion_Num_Imp)
                .ForeignKey("dbo.Items", t => t.I_Code, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_Supplier_Id)
                .ForeignKey("dbo.WareHouses", t => t.WH_Name)
                .Index(t => t.I_Code)
                .Index(t => t.WH_Name)
                .Index(t => t.Supplier_Supplier_Id);
            
            CreateTable(
                "dbo.WareHouses",
                c => new
                    {
                        WH_Name = c.String(nullable: false, maxLength: 128),
                        WH_Address = c.String(),
                        WH_Manager = c.String(),
                    })
                .PrimaryKey(t => t.WH_Name);
            
            CreateTable(
                "dbo.item_WareHouse",
                c => new
                    {
                        WH_Name = c.String(nullable: false, maxLength: 128),
                        I_Code = c.Int(nullable: false),
                        Quantity = c.Int(),
                    })
                .PrimaryKey(t => new { t.WH_Name, t.I_Code })
                .ForeignKey("dbo.Items", t => t.I_Code, cascadeDelete: true)
                .ForeignKey("dbo.WareHouses", t => t.WH_Name, cascadeDelete: true)
                .Index(t => t.WH_Name)
                .Index(t => t.I_Code);
            
            CreateTable(
                "dbo.Move_To",
                c => new
                    {
                        I_Code = c.Int(nullable: false),
                        FromWH_Nm = c.String(nullable: false, maxLength: 128),
                        ToWH_Nm = c.String(nullable: false, maxLength: 128),
                        Quantity = c.Int(),
                        Move_Date = c.DateTime(nullable: false),
                        Production_Date = c.DateTime(nullable: false),
                        Expire_Date = c.DateTime(nullable: false),
                        WareHouse_WH_Name = c.String(maxLength: 128),
                        WareHouse1_WH_Name = c.String(maxLength: 128),
                        WareHouse_WH_Name1 = c.String(maxLength: 128),
                        WareHouse_WH_Name2 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.I_Code, t.FromWH_Nm, t.ToWH_Nm })
                .ForeignKey("dbo.Items", t => t.I_Code, cascadeDelete: true)
                .ForeignKey("dbo.WareHouses", t => t.WareHouse_WH_Name)
                .ForeignKey("dbo.WareHouses", t => t.WareHouse1_WH_Name)
                .ForeignKey("dbo.WareHouses", t => t.WareHouse_WH_Name1)
                .ForeignKey("dbo.WareHouses", t => t.WareHouse_WH_Name2)
                .Index(t => t.I_Code)
                .Index(t => t.WareHouse_WH_Name)
                .Index(t => t.WareHouse1_WH_Name)
                .Index(t => t.WareHouse_WH_Name1)
                .Index(t => t.WareHouse_WH_Name2);
            
            CreateTable(
                "dbo.Permetion_Export",
                c => new
                    {
                        Permetion_Num_Exp = c.Int(nullable: false, identity: true),
                        I_Code = c.Int(nullable: false),
                        WH_Name = c.String(maxLength: 128),
                        Customer_Email = c.String(),
                        Permetion_Date_Exp = c.DateTime(nullable: false),
                        Customer_Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Permetion_Num_Exp)
                .ForeignKey("dbo.Customer", t => t.Customer_Customer_Id)
                .ForeignKey("dbo.Items", t => t.I_Code, cascadeDelete: false)
                .ForeignKey("dbo.WareHouses", t => t.WH_Name)
                .Index(t => t.I_Code)
                .Index(t => t.WH_Name)
                .Index(t => t.Customer_Customer_Id);
            
            CreateTable(
                "dbo.Item_Measure",
                c => new
                    {
                        I_Code = c.Int(nullable: false),
                        Measure = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.I_Code, t.Measure })
                .ForeignKey("dbo.Items", t => t.I_Code, cascadeDelete: true)
                .Index(t => t.I_Code);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item_Measure", "I_Code", "dbo.Items");
            DropForeignKey("dbo.Permetion_Import", "WH_Name", "dbo.WareHouses");
            DropForeignKey("dbo.Permetion_Export", "WH_Name", "dbo.WareHouses");
            DropForeignKey("dbo.Permetion_Export", "I_Code", "dbo.Items");
            DropForeignKey("dbo.Export_Quantity", "Permetion_Num_Exp", "dbo.Permetion_Export");
            DropForeignKey("dbo.Permetion_Export", "Customer_Customer_Id", "dbo.Customer");
            DropForeignKey("dbo.Move_To", "WareHouse_WH_Name2", "dbo.WareHouses");
            DropForeignKey("dbo.Move_To", "WareHouse_WH_Name1", "dbo.WareHouses");
            DropForeignKey("dbo.Move_To", "WareHouse1_WH_Name", "dbo.WareHouses");
            DropForeignKey("dbo.Move_To", "WareHouse_WH_Name", "dbo.WareHouses");
            DropForeignKey("dbo.Move_To", "I_Code", "dbo.Items");
            DropForeignKey("dbo.item_WareHouse", "WH_Name", "dbo.WareHouses");
            DropForeignKey("dbo.item_WareHouse", "I_Code", "dbo.Items");
            DropForeignKey("dbo.Import_Quantity", "WH_Name", "dbo.WareHouses");
            DropForeignKey("dbo.Export_Quantity", "WH_Name", "dbo.WareHouses");
            DropForeignKey("dbo.Permetion_Import", "Supplier_Supplier_Id", "dbo.Suppliers");
            DropForeignKey("dbo.Import_Quantity", "Supplier_Supplier_Id", "dbo.Suppliers");
            DropForeignKey("dbo.Permetion_Import", "I_Code", "dbo.Items");
            DropForeignKey("dbo.Import_Quantity", "Permetion_Import_Permetion_Num_Imp", "dbo.Permetion_Import");
            DropForeignKey("dbo.Import_Quantity", "I_Code", "dbo.Items");
            DropForeignKey("dbo.Export_Quantity", "I_Code", "dbo.Items");
            DropForeignKey("dbo.Export_Quantity", "Customer_Customer_Id", "dbo.Customer");
            DropIndex("dbo.Item_Measure", new[] { "I_Code" });
            DropIndex("dbo.Permetion_Export", new[] { "Customer_Customer_Id" });
            DropIndex("dbo.Permetion_Export", new[] { "WH_Name" });
            DropIndex("dbo.Permetion_Export", new[] { "I_Code" });
            DropIndex("dbo.Move_To", new[] { "WareHouse_WH_Name2" });
            DropIndex("dbo.Move_To", new[] { "WareHouse_WH_Name1" });
            DropIndex("dbo.Move_To", new[] { "WareHouse1_WH_Name" });
            DropIndex("dbo.Move_To", new[] { "WareHouse_WH_Name" });
            DropIndex("dbo.Move_To", new[] { "I_Code" });
            DropIndex("dbo.item_WareHouse", new[] { "I_Code" });
            DropIndex("dbo.item_WareHouse", new[] { "WH_Name" });
            DropIndex("dbo.Permetion_Import", new[] { "Supplier_Supplier_Id" });
            DropIndex("dbo.Permetion_Import", new[] { "WH_Name" });
            DropIndex("dbo.Permetion_Import", new[] { "I_Code" });
            DropIndex("dbo.Import_Quantity", new[] { "Supplier_Supplier_Id" });
            DropIndex("dbo.Import_Quantity", new[] { "Permetion_Import_Permetion_Num_Imp" });
            DropIndex("dbo.Import_Quantity", new[] { "WH_Name" });
            DropIndex("dbo.Import_Quantity", new[] { "I_Code" });
            DropIndex("dbo.Export_Quantity", new[] { "Customer_Customer_Id" });
            DropIndex("dbo.Export_Quantity", new[] { "WH_Name" });
            DropIndex("dbo.Export_Quantity", new[] { "I_Code" });
            DropIndex("dbo.Export_Quantity", new[] { "Permetion_Num_Exp" });
            DropTable("dbo.Item_Measure");
            DropTable("dbo.Permetion_Export");
            DropTable("dbo.Move_To");
            DropTable("dbo.item_WareHouse");
            DropTable("dbo.WareHouses");
            DropTable("dbo.Permetion_Import");
            DropTable("dbo.Import_Quantity");
            DropTable("dbo.Items");
            DropTable("dbo.Export_Quantity");
        }
    }
}
