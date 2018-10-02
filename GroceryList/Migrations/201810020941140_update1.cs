namespace GroceryList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Groceries", "Store", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Groceries", "Store", c => c.String());
        }
    }
}
