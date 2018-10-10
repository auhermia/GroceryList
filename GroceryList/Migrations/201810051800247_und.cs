namespace GroceryList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class und : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.GroceryViewModels");
            AddColumn("dbo.GroceryViewModels", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.GroceryViewModels", "SelectedMarket", c => c.String());
            AddColumn("dbo.GroceryViewModels", "Item", c => c.String());
            AddPrimaryKey("dbo.GroceryViewModels", "Id");
            DropColumn("dbo.GroceryViewModels", "MarketId");
            DropColumn("dbo.GroceryViewModels", "Market");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GroceryViewModels", "Market", c => c.String());
            AddColumn("dbo.GroceryViewModels", "MarketId", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.GroceryViewModels");
            DropColumn("dbo.GroceryViewModels", "Item");
            DropColumn("dbo.GroceryViewModels", "SelectedMarket");
            DropColumn("dbo.GroceryViewModels", "Id");
            AddPrimaryKey("dbo.GroceryViewModels", "MarketId");
        }
    }
}
