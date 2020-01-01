namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedExtraProperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "InvoiceId", "dbo.Invoices");
            DropIndex("dbo.Transactions", new[] { "InvoiceId" });
            AddColumn("dbo.PaymentInfoes", "StripeToken", c => c.String());
            DropColumn("dbo.Employees", "StreetAddress");
            DropColumn("dbo.Employees", "City");
            DropColumn("dbo.Employees", "State");
            DropColumn("dbo.Employees", "ZipCode");
            DropColumn("dbo.PaymentInfoes", "NameOnCard");
            DropColumn("dbo.PaymentInfoes", "CreditCardNumber");
            DropColumn("dbo.PaymentInfoes", "CreditCardExpirationDate");
            DropColumn("dbo.PaymentInfoes", "CreditCardSecurityCode");
            DropColumn("dbo.Transactions", "InvoiceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "InvoiceId", c => c.Int(nullable: false));
            AddColumn("dbo.PaymentInfoes", "CreditCardSecurityCode", c => c.Int(nullable: false));
            AddColumn("dbo.PaymentInfoes", "CreditCardExpirationDate", c => c.String());
            AddColumn("dbo.PaymentInfoes", "CreditCardNumber", c => c.String());
            AddColumn("dbo.PaymentInfoes", "NameOnCard", c => c.String());
            AddColumn("dbo.Employees", "ZipCode", c => c.String());
            AddColumn("dbo.Employees", "State", c => c.String());
            AddColumn("dbo.Employees", "City", c => c.String());
            AddColumn("dbo.Employees", "StreetAddress", c => c.String());
            DropColumn("dbo.PaymentInfoes", "StripeToken");
            CreateIndex("dbo.Transactions", "InvoiceId");
            AddForeignKey("dbo.Transactions", "InvoiceId", "dbo.Invoices", "InvoiceId", cascadeDelete: true);
        }
    }
}
