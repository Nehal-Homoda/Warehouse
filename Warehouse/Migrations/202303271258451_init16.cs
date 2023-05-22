namespace Warehouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init16 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Permetion_Export", "Permetion_Date_Exp", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Permetion_Export", "Permetion_Date_Exp", c => c.DateTime(nullable: false));
        }
    }
}
