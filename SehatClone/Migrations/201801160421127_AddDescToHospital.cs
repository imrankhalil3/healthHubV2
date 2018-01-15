namespace SehatClone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescToHospital : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hospitals", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hospitals", "Description");
        }
    }
}
