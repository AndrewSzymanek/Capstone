namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Contractors",
                c => new
                    {
                        ContractorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        PhoneNumber = c.String(),
                        ApplicationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ContractorId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        DayId = c.Int(nullable: false, identity: true),
                        TimeIn = c.String(),
                        TimeOut = c.String(),
                        HoursWorked = c.Double(nullable: false),
                        DaysPay = c.Double(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DayId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        PhoneNumber = c.String(),
                        HourlyRate = c.Double(nullable: false),
                        ApplicationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.Employee_Task",
                c => new
                    {
                        Employee_TaskId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Employee_TaskId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        TaskName = c.String(),
                        IsComplete = c.Boolean(nullable: false),
                        JobId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .Index(t => t.JobId);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobId = c.Int(nullable: false, identity: true),
                        JobName = c.String(),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        MaterialsCost = c.Double(nullable: false),
                        LaborCost = c.Double(nullable: false),
                        TotalLiabilities = c.Double(nullable: false),
                        PaymentReceived = c.Double(nullable: false),
                        DaysToComplete = c.Int(nullable: false),
                        IsComplete = c.Boolean(nullable: false),
                        ProfitabilityRatio = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.JobId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        InvoiceAmount = c.Double(nullable: false),
                        DueDate = c.String(),
                        IsPaid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId);
            
            CreateTable(
                "dbo.PaymentInfoes",
                c => new
                    {
                        PaymentInfoId = c.Int(nullable: false, identity: true),
                        NameOnCard = c.String(),
                        CreditCardNumber = c.String(),
                        CreditCardExpirationDate = c.String(),
                        CreditCardSecurityCode = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentInfoId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        ContractorId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        JobId = c.Int(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Contractors", t => t.ContractorId, cascadeDelete: true)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .Index(t => t.ContractorId)
                .Index(t => t.ClientId)
                .Index(t => t.JobId)
                .Index(t => t.InvoiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Transactions", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Transactions", "ContractorId", "dbo.Contractors");
            DropForeignKey("dbo.Transactions", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PaymentInfoes", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Employee_Task", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.Tasks", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Employee_Task", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Days", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contractors", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Transactions", new[] { "InvoiceId" });
            DropIndex("dbo.Transactions", new[] { "JobId" });
            DropIndex("dbo.Transactions", new[] { "ClientId" });
            DropIndex("dbo.Transactions", new[] { "ContractorId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PaymentInfoes", new[] { "ClientId" });
            DropIndex("dbo.Tasks", new[] { "JobId" });
            DropIndex("dbo.Employee_Task", new[] { "TaskId" });
            DropIndex("dbo.Employee_Task", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "ApplicationId" });
            DropIndex("dbo.Days", new[] { "EmployeeId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Contractors", new[] { "ApplicationId" });
            DropTable("dbo.Transactions");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PaymentInfoes");
            DropTable("dbo.Invoices");
            DropTable("dbo.Jobs");
            DropTable("dbo.Tasks");
            DropTable("dbo.Employee_Task");
            DropTable("dbo.Employees");
            DropTable("dbo.Days");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Contractors");
            DropTable("dbo.Clients");
        }
    }
}
