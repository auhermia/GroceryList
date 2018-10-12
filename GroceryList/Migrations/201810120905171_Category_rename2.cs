namespace GroceryList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Category_rename2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Groceries", "CategoryId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Groceries", "CategoryId", c => c.String(nullable: false));
        }
    }
}
