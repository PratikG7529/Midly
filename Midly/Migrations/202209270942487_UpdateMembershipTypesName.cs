namespace Midly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypesName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Pay as you go' WHERE Duration=0");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE Duration=1");
            Sql("UPDATE MembershipTypes SET Name = 'Quaterly' WHERE Duration=3");
            Sql("UPDATE MembershipTypes SET Name = 'Yearly' WHERE Duration=12");
        }

        public override void Down()
        {
        }
    }
}
