namespace TestApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateColumnType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Phone", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "CardNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "CardExpirationMonth", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "CardExpirationYear", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "CardSecurityCode", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Price", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Orders", "CardSecurityCode", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Orders", "CardExpirationYear", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Orders", "CardExpirationMonth", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Orders", "CardNumber", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Orders", "Phone", c => c.String(maxLength: 10, unicode: false));
        }
    }
}
