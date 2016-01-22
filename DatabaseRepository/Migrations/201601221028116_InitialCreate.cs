namespace DatabaseRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PetType = c.String(),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "OwnerId", "dbo.People");
            DropIndex("dbo.Pets", new[] { "OwnerId" });
            DropTable("dbo.Pets");
            DropTable("dbo.People");
        }
    }
}
