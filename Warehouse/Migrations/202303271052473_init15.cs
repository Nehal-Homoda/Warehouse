namespace Warehouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init15 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Permetion_Import", "Permetion_Date_I", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Permetion_Import", "Permetion_Date_I", c => c.DateTime(nullable: false));
        }
    }
}
