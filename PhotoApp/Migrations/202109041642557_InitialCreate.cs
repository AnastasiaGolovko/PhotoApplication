namespace PhotoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CoachModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fname = c.String(),
                        Sname = c.String(),
                        Tname = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContractModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContractNumber = c.String(),
                        StudentId = c.Int(nullable: false),
                        SeasonId = c.Int(nullable: false),
                        ContractTime = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GroupModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupNumber = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        Satus = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GroupStudentModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        StugentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SeasonModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Cost = c.Double(nullable: false),
                        SubjectCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fname = c.String(),
                        Sname = c.String(),
                        Tname = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubjectModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectTime = c.DateTime(nullable: false),
                        SubjectType = c.String(),
                        Topic = c.String(),
                        CoachId = c.Int(nullable: false),
                        Place = c.String(),
                        GroupId = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SubjectModels");
            DropTable("dbo.StudentModels");
            DropTable("dbo.SeasonModels");
            DropTable("dbo.GroupStudentModels");
            DropTable("dbo.GroupModels");
            DropTable("dbo.ContractModels");
            DropTable("dbo.CoachModels");
        }
    }
}
