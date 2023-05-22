namespace Warehouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemsPers",
                c => new
                    {
                        ProductName = c.String(nullable: false, maxLength: 128),
                        ItemQuantity = c.Int(nullable: false),
                        oldQuantity = c.Int(nullable: false),
                        ProdDate = c.DateTime(nullable: false),
                        ExpiDate = c.DateTime(nullable: false),
                        oldRecord = c.String(),
                    })
                .PrimaryKey(t => t.ProductName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ItemsPers");
        }
    }
}
