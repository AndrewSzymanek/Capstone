namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedDaysPayAndHourly : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Days", "DaysPay");
            DropColumn("dbo.Employees", "HourlyRate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "HourlyRate", c => c.Double(nullable: false));
            AddColumn("dbo.Days", "DaysPay", c => c.Double(nullable: false));
        }
    }
}
