namespace Warehouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init14 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Import_Quantity", "Prod_Date", c => c.DateTime());
            AlterColumn("dbo.Import_Quantity", "Expi_Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Import_Quantity", "Expi_Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Import_Quantity", "Prod_Date", c => c.DateTime(nullable: false));
        }
    }
}
