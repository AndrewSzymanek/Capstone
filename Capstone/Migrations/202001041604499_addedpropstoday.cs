namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpropstoday : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Days", "TodaysDate", c => c.String());
            AddColumn("dbo.Days", "MinutesWorked", c => c.Double());
            DropColumn("dbo.Days", "HoursWorked");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Days", "HoursWorked", c => c.Double(nullable: false));
            DropColumn("dbo.Days", "MinutesWorked");
            DropColumn("dbo.Days", "TodaysDate");
        }
    }
}
