namespace PhotoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupStudentRepModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupNumber = c.String(),
                        Fname = c.String(),
                        Sname = c.String(),
                        Tname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubjectRepModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectTime = c.DateTime(nullable: false),
                        SubjectType = c.String(),
                        Topic = c.String(),
                        Fname = c.String(),
                        Sname = c.String(),
                        Tname = c.String(),
                        Place = c.String(),
                        GroupNumber = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SubjectRepModels");
            DropTable("dbo.GroupStudentRepModels");
        }
    }
}
