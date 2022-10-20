namespace Midly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert INTO Genres (Id,GenreName) values (1,'Comedy')");
            Sql("Insert INTO Genres (Id,GenreName) values (2,'Horror')");
            Sql("Insert INTO Genres (Id,GenreName) values (3,'Action')");
            Sql("Insert INTO Genres (Id,GenreName) values (4,'Romantic')");
            Sql("Insert INTO Genres (Id,GenreName) values (5,'Sify')");
        }
        
        public override void Down()
        {
        }
    }
}
