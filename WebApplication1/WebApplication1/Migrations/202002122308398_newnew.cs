namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newnew : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shops", "ApplicationId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Shops", "ApplicationId");
            AddForeignKey("dbo.Shops", "ApplicationId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shops", "ApplicationId", "dbo.AspNetUsers");
            DropIndex("dbo.Shops", new[] { "ApplicationId" });
            DropColumn("dbo.Shops", "ApplicationId");
        }
    }
}
