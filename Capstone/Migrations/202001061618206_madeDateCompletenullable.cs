namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madeDateCompletenullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "DateCompleted", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "DateCompleted", c => c.DateTime(nullable: false));
        }
    }
}
