namespace Warehouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Supplier_Id = c.Int(nullable: false, identity: true),
                        Supplier_Name = c.String(),
                        Supplier_Phone = c.Int(nullable: false),
                        Supplier_Email = c.String(),
                        Supplier_Website = c.String(),
                        Supplier_Fax = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Supplier_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Suppliers");
        }
    }
}
