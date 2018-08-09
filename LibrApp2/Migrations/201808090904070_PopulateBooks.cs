namespace LibrApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBooks : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Books ON");
            Sql("INSERT into Books (Id, Name, DatePublished, GenreId) VALUES (1, 'Ender''s Game', '01-15-1985', 1)");
            Sql("INSERT into Books (Id, Name, DatePublished, GenreId) VALUES (2, 'The Martian', '02-11-2014', 1)");
            Sql("INSERT into Books (Id, Name, DatePublished, GenreId) VALUES (3, 'The Name of the wind', '03-27-2007', 2)");
            Sql("INSERT into Books (Id, Name, DatePublished, GenreId) VALUES (4, 'Think like a programmer', '08-11-2012', 5)");
            Sql("INSERT into Books (Id, Name, DatePublished, GenreId) VALUES (5, 'Julius Ceasar - The Commentaries On the Gallic War & On the Civil War', '10-01-2006', 6)");
            Sql("INSERT into Books (Id, Name, DatePublished, GenreId) VALUES (6, 'The Wise Man''s Fear', '03-01-2011', 2)");
            Sql("INSERT into Books (Id, Name, DatePublished, GenreId) VALUES (7, 'Test book', '03-01-2018', 5)");
            Sql("SET IDENTITY_INSERT Books OFF");
        }

        public override void Down()
        {
        }
    }
}
