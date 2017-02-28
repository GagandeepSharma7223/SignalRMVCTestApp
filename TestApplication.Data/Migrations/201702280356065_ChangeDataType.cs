namespace TestApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DevTests", "CampaignName", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.DevTests", "AffiliateName", c => c.String(maxLength: 255, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DevTests", "AffiliateName", c => c.String());
            AlterColumn("dbo.DevTests", "CampaignName", c => c.String());
        }
    }
}
