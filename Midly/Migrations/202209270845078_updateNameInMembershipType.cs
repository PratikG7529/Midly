namespace Midly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateNameInMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Quaterly' WHERE Duration=3");
            //Sql("Update MembershipTypes set Name = 'Pay as you go' where Duration = 0");
            //Sql("Update MembershipTypes set Name = 'Monthly' where Duration = 1");
            //Sql("Update MembershipTypes set Name = 'Quaterly' where Duration = 3");
            //Sql("Update MembershipTypes set Name = 'Yearly' where Duration = 12");
        }
        
        public override void Down()
        {
        }
    }
}
