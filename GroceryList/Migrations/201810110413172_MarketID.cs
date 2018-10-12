namespace GroceryList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MarketID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groceries", "MarketId", c => c.String(nullable: false));
            DropColumn("dbo.Groceries", "Market");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groceries", "Market", c => c.String(nullable: false));
            DropColumn("dbo.Groceries", "MarketId");
        }
    }
}
