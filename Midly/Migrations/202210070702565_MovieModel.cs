namespace Midly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "MovieReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "MovieAddedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "ReleaseDate");
            DropColumn("dbo.Movies", "DateAdded");
            DropTable("dbo.Genres");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Movies", "MovieAddedDate");
            DropColumn("dbo.Movies", "MovieReleaseDate");
        }
    }
}
