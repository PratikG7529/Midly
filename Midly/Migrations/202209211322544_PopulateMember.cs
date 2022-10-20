namespace Midly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMember : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into membershipTypes (Id,SignupFee,Duration,DiscountRate) values (1,0,0,0)");
            Sql("Insert into membershipTypes (Id,SignupFee,Duration,DiscountRate) values (2,30,1,0)");
            Sql("Insert into membershipTypes (Id,SignupFee,Duration,DiscountRate) values (3,90,3,15)");
            Sql("Insert into membershipTypes (Id,SignupFee,Duration,DiscountRate) values (4,300,12,20)");


        }
        
        public override void Down()
        {
        }
    }
}
