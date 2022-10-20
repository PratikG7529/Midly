namespace Midly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdayDetails : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = '11/12/1966' WHERE Id=1");
            Sql("UPDATE Customers SET Birthdate = '13/03/2022' WHERE Id=3");
        }
        
        public override void Down()
        {
        }
    }
}
