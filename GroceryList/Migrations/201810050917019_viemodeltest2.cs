namespace GroceryList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class viemodeltest2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.GroceryViewModels");
            AddColumn("dbo.GroceryViewModels", "MarketId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.GroceryViewModels", "MarketId");
            DropColumn("dbo.GroceryViewModels", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GroceryViewModels", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.GroceryViewModels");
            DropColumn("dbo.GroceryViewModels", "MarketId");
            AddPrimaryKey("dbo.GroceryViewModels", "Id");
        }
    }
}
