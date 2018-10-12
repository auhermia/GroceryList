namespace GroceryList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Groceries", "MarketId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Groceries", "MarketId", c => c.String(nullable: false));
        }
    }
}
