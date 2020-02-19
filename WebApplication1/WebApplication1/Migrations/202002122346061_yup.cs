namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shops", "MechanicId", "dbo.Mechanics");
            DropIndex("dbo.Shops", new[] { "MechanicId" });
            DropColumn("dbo.Shops", "MechanicId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shops", "MechanicId", c => c.Int(nullable: false));
            CreateIndex("dbo.Shops", "MechanicId");
            AddForeignKey("dbo.Shops", "MechanicId", "dbo.Mechanics", "MechanicId", cascadeDelete: true);
        }
    }
}
