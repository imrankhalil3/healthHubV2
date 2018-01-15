namespace SehatClone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageUrlToHospital : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hospitals", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hospitals", "ImageUrl");
        }
    }
}
