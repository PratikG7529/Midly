namespace Midly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenreandMoviesEntitiesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        GenreType = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.GenreId);
            
            AddColumn("dbo.Movies", "ReleaseDate", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Stock", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Genre_GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "Genre_GenreId");
            AddForeignKey("dbo.Movies", "Genre_GenreId", "dbo.Genres", "GenreId", cascadeDelete: true);
            DropColumn("dbo.Movies", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Genre", c => c.String(nullable: false, maxLength: 50));
            DropForeignKey("dbo.Movies", "Genre_GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_GenreId" });
            DropColumn("dbo.Movies", "Genre_GenreId");
            DropColumn("dbo.Movies", "Stock");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "ReleaseDate");
            DropTable("dbo.Genres");
        }
    }
}
