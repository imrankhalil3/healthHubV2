namespace SehatClone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHospitalsTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hospitals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactName = c.String(),
                        Location = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        ConfirmPassword = c.String(),
                        Phone = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Hospitals");
        }
    }
}
