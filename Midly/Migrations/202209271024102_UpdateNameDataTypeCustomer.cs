namespace Midly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNameDataTypeCustomer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Birthdate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Birthdate", c => c.DateTime(nullable: false));
        }
    }
}
