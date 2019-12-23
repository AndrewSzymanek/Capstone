namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullablejobproperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "MaterialsCost", c => c.Double());
            AlterColumn("dbo.Jobs", "LaborCost", c => c.Double());
            AlterColumn("dbo.Jobs", "TotalLiabilities", c => c.Double());
            AlterColumn("dbo.Jobs", "PaymentReceived", c => c.Double());
            AlterColumn("dbo.Jobs", "DaysToComplete", c => c.Int());
            AlterColumn("dbo.Jobs", "IsComplete", c => c.Boolean());
            AlterColumn("dbo.Jobs", "ProfitabilityRatio", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "ProfitabilityRatio", c => c.Double(nullable: false));
            AlterColumn("dbo.Jobs", "IsComplete", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Jobs", "DaysToComplete", c => c.Int(nullable: false));
            AlterColumn("dbo.Jobs", "PaymentReceived", c => c.Double(nullable: false));
            AlterColumn("dbo.Jobs", "TotalLiabilities", c => c.Double(nullable: false));
            AlterColumn("dbo.Jobs", "LaborCost", c => c.Double(nullable: false));
            AlterColumn("dbo.Jobs", "MaterialsCost", c => c.Double(nullable: false));
        }
    }
}
