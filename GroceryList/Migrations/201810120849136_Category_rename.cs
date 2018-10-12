namespace GroceryList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Category_rename : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groceries", "CategoryId", c => c.String(nullable: false));
            DropColumn("dbo.Groceries", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groceries", "Category", c => c.String(nullable: false));
            DropColumn("dbo.Groceries", "CategoryId");
        }
    }
}
