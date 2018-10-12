namespace GroceryList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groceries", "Category", c => c.String(nullable: false));
            DropColumn("dbo.Groceries", "ItemCategory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groceries", "ItemCategory", c => c.String(nullable: false));
            DropColumn("dbo.Groceries", "Category");
        }
    }
}
