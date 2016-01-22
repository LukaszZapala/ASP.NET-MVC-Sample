namespace Sklep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductOrdersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ProductName = c.String(),
                        Count = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderProducts", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderProducts", new[] { "OrderId" });
            DropTable("dbo.OrderProducts");
        }
    }
}
