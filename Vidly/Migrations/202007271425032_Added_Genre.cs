namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Genre : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);

            Sql("SET IDENTITY_INSERT Genres ON");
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Thriller')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Drama')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Romance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Sci-Fi')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7, 'Documentary')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (8, 'History')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (9, 'Animation')");
            Sql("SET IDENTITY_INSERT Genres OFF");

        }
        
        public override void Down()
        {
            DropTable("dbo.Genres");
        }
    }
}
