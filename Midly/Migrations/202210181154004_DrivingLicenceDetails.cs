namespace Midly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrivingLicenceDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DrivingLicence", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DrivingLicence");
        }
    }
}
