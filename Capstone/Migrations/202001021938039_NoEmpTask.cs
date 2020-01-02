namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoEmpTask : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employee_Task", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employee_Task", "TaskId", "dbo.Tasks");
            DropIndex("dbo.Employee_Task", new[] { "EmployeeId" });
            DropIndex("dbo.Employee_Task", new[] { "TaskId" });
            AddColumn("dbo.Employees", "ContractorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "ContractorId");
            AddForeignKey("dbo.Employees", "ContractorId", "dbo.Contractors", "ContractorId", cascadeDelete: true);
            DropTable("dbo.Employee_Task");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Employee_Task",
                c => new
                    {
                        Employee_TaskId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Employee_TaskId);
            
            DropForeignKey("dbo.Employees", "ContractorId", "dbo.Contractors");
            DropIndex("dbo.Employees", new[] { "ContractorId" });
            DropColumn("dbo.Employees", "ContractorId");
            CreateIndex("dbo.Employee_Task", "TaskId");
            CreateIndex("dbo.Employee_Task", "EmployeeId");
            AddForeignKey("dbo.Employee_Task", "TaskId", "dbo.Tasks", "TaskId", cascadeDelete: true);
            AddForeignKey("dbo.Employee_Task", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
        }
    }
}
