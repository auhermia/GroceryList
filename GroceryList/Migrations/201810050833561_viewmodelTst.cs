namespace GroceryList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class viewmodelTst : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroceryViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Market = c.String(),
                        Grocery_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groceries", t => t.Grocery_Id)
                .Index(t => t.Grocery_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroceryViewModels", "Grocery_Id", "dbo.Groceries");
            DropIndex("dbo.GroceryViewModels", new[] { "Grocery_Id" });
            DropTable("dbo.GroceryViewModels");
        }
    }
}
