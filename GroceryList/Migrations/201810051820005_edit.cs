namespace GroceryList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GroceryViewModels", "Grocery_Id", "dbo.Groceries");
            DropIndex("dbo.GroceryViewModels", new[] { "Grocery_Id" });
            DropTable("dbo.GroceryViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GroceryViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SelectedMarket = c.String(),
                        Item = c.String(),
                        Grocery_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.GroceryViewModels", "Grocery_Id");
            AddForeignKey("dbo.GroceryViewModels", "Grocery_Id", "dbo.Groceries", "Id");
        }
    }
}
