namespace Warehouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init24 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "Customer_Phone", c => c.Int());
            AlterColumn("dbo.Move_To", "Expire_Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Move_To", "Expire_Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customer", "Customer_Phone", c => c.Int(nullable: false));
        }
    }
}
