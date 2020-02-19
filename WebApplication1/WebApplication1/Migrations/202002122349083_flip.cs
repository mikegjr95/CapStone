namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class flip : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shops", "OrderId", "dbo.RepairOrders");
            DropIndex("dbo.Shops", new[] { "OrderId" });
            DropColumn("dbo.Shops", "OrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shops", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Shops", "OrderId");
            AddForeignKey("dbo.Shops", "OrderId", "dbo.RepairOrders", "OrderId", cascadeDelete: true);
        }
    }
}
