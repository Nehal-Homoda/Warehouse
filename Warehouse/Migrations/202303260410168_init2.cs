namespace Warehouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "Customer_Mobile", c => c.Int(nullable: false));
            AddColumn("dbo.Suppliers", "Supplier_Mobile", c => c.Int(nullable: false));
            AlterColumn("dbo.Customer", "Customer_Fax", c => c.String());
            AlterColumn("dbo.Suppliers", "Supplier_Fax", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Suppliers", "Supplier_Fax", c => c.Int(nullable: false));
            AlterColumn("dbo.Customer", "Customer_Fax", c => c.Int(nullable: false));
            DropColumn("dbo.Suppliers", "Supplier_Mobile");
            DropColumn("dbo.Customer", "Customer_Mobile");
        }
    }
}
