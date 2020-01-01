namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedAddressPropContractor : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contractors", "StreetAddress");
            DropColumn("dbo.Contractors", "City");
            DropColumn("dbo.Contractors", "State");
            DropColumn("dbo.Contractors", "ZipCode");
            DropColumn("dbo.Contractors", "PhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contractors", "PhoneNumber", c => c.String());
            AddColumn("dbo.Contractors", "ZipCode", c => c.String());
            AddColumn("dbo.Contractors", "State", c => c.String());
            AddColumn("dbo.Contractors", "City", c => c.String());
            AddColumn("dbo.Contractors", "StreetAddress", c => c.String());
        }
    }
}
