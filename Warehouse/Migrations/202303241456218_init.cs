namespace Warehouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clients");
        }
    }
}
