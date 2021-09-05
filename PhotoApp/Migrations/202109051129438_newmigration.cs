namespace PhotoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GroupStudentModels", "StudentId", c => c.Int(nullable: false));
            DropColumn("dbo.GroupStudentModels", "StugentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GroupStudentModels", "StugentId", c => c.Int(nullable: false));
            DropColumn("dbo.GroupStudentModels", "StudentId");
        }
    }
}
