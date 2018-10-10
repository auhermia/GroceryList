namespace GroceryList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groceries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Market = c.String(nullable: false),
                        Item = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Markets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MarketName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Markets");
            DropTable("dbo.Groceries");
        }
    }
}
