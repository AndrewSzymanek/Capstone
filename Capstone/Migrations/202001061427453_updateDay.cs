namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "DateCompleted", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "DateCompleted");
        }
    }
}
