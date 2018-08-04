namespace LibrApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT into Genres (Id, Name) VALUES (1, 'Science-fiction')");
            Sql("INSERT into Genres (Id, Name) VALUES (2, 'Fantasy')");
            Sql("INSERT into Genres (Id, Name) VALUES (3, 'Horror')");
            Sql("INSERT into Genres (Id, Name) VALUES (4, 'Self-development')");
            Sql("INSERT into Genres (Id, Name) VALUES (5, 'Computer science')");
            Sql("INSERT into Genres (Id, Name) VALUES (6, 'History')");
        }
        
        public override void Down()
        {
        }
    }
}
