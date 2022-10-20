namespace Midly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieModelAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Genre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
