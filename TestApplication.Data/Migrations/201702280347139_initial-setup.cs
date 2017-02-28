namespace TestApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialsetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DevTests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CampaignName = c.String(),
                        Date = c.DateTime(),
                        Clicks = c.Int(),
                        Conversions = c.Int(),
                        Impressions = c.Int(),
                        AffiliateName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DevTests");
        }
    }
}
