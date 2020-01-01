namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emploee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contractors", "BusinessName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contractors", "BusinessName");
        }
    }
}
