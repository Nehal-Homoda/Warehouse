namespace Warehouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "Prod_Date", c => c.DateTime());
            AlterColumn("dbo.Items", "Expi_Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "Expi_Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Items", "Prod_Date", c => c.DateTime(nullable: false));
        }
    }
}
