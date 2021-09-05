namespace PhotoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class n1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContractRepModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContractNumber = c.String(),
                        Fname = c.String(),
                        Sname = c.String(),
                        Tname = c.String(),
                        Name = c.String(),
                        Cost = c.Double(nullable: false),
                        SubjectCount = c.Int(nullable: false),
                        ContractTime = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContractRepModels");
        }
    }
}
