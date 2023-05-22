namespace Warehouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init23 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Export_Quantity", "Prod_Date", c => c.DateTime());
            AlterColumn("dbo.Export_Quantity", "Expi_Date", c => c.DateTime());
            AlterColumn("dbo.ItemsPers", "ProdDate", c => c.DateTime());
            AlterColumn("dbo.ItemsPers", "ExpiDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ItemsPers", "ExpiDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ItemsPers", "ProdDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Export_Quantity", "Expi_Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Export_Quantity", "Prod_Date", c => c.DateTime(nullable: false));
        }
    }
}
