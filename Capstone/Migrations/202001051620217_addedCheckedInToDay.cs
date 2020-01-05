namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCheckedInToDay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Days", "CheckedIn", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Days", "CheckedIn");
        }
    }
}
