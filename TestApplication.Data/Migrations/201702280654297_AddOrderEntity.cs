namespace TestApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 255, unicode: false),
                        LastName = c.String(maxLength: 255, unicode: false),
                        Address = c.String(),
                        City = c.String(maxLength: 255, unicode: false),
                        State = c.String(maxLength: 255, unicode: false),
                        Zip = c.String(maxLength: 10, unicode: false),
                        Phone = c.String(maxLength: 10, unicode: false),
                        Email = c.String(maxLength: 255, unicode: false),
                        CardNumber = c.String(maxLength: 255, unicode: false),
                        CardExpirationMonth = c.String(maxLength: 255, unicode: false),
                        CardExpirationYear = c.String(maxLength: 255, unicode: false),
                        CardSecurityCode = c.String(maxLength: 255, unicode: false),
                        Price = c.String(maxLength: 255, unicode: false),
                        Status = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
        }
    }
}
