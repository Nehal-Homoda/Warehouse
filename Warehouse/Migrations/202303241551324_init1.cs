namespace Warehouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Customer_Id = c.Int(nullable: false, identity: true),
                        Customer_Name = c.String(),
                        Customer_Phone = c.Int(nullable: false),
                        Customer_Email = c.String(),
                        Customer_Website = c.String(),
                        Customer_Fax = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Customer_Id);
            
            DropTable("dbo.Clients");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        client_Id = c.Int(nullable: false, identity: true),
                        client_Name = c.String(),
                        client_Phone = c.Int(nullable: false),
                        client_Email = c.String(),
                        client_Website = c.String(),
                        client_Fax = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.client_Id);
            
            DropTable("dbo.Customer");
        }
    }
}
