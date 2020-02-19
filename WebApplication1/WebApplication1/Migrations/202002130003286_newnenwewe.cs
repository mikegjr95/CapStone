namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newnenwewe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shops", "StreetP", c => c.String());
            AddColumn("dbo.Shops", "StreetMc", c => c.String());
            AddColumn("dbo.Shops", "StreetM", c => c.String());
            AddColumn("dbo.Shops", "ZipP", c => c.Int(nullable: false));
            AddColumn("dbo.Shops", "ZipM", c => c.Int(nullable: false));
            AddColumn("dbo.Shops", "ZipMc", c => c.Int(nullable: false));
            AddColumn("dbo.Shops", "StateM", c => c.String());
            AddColumn("dbo.Shops", "StateP", c => c.String());
            AddColumn("dbo.Shops", "StateMc", c => c.String());
            DropColumn("dbo.Shops", "Street");
            DropColumn("dbo.Shops", "Zip");
            DropColumn("dbo.Shops", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shops", "State", c => c.String());
            AddColumn("dbo.Shops", "Zip", c => c.Int(nullable: false));
            AddColumn("dbo.Shops", "Street", c => c.String());
            DropColumn("dbo.Shops", "StateMc");
            DropColumn("dbo.Shops", "StateP");
            DropColumn("dbo.Shops", "StateM");
            DropColumn("dbo.Shops", "ZipMc");
            DropColumn("dbo.Shops", "ZipM");
            DropColumn("dbo.Shops", "ZipP");
            DropColumn("dbo.Shops", "StreetM");
            DropColumn("dbo.Shops", "StreetMc");
            DropColumn("dbo.Shops", "StreetP");
        }
    }
}
