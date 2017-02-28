namespace TestApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePhoneType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Phone", c => c.String(maxLength: 13, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Phone", c => c.Int(nullable: false));
        }
    }
}
