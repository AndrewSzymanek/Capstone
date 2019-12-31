namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedlatlongtojob : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Lat", c => c.String());
            AddColumn("dbo.Jobs", "Long", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "Long");
            DropColumn("dbo.Jobs", "Lat");
        }
    }
}
