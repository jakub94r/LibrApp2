namespace LibrApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAuthors : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Authors ON");
            Sql("INSERT into Authors (Id, FullName) VALUES (1, 'Orson Scott Card')");
            Sql("INSERT into Authors (Id, FullName) VALUES (2, 'Andy Weir')");
            Sql("INSERT into Authors (Id, FullName) VALUES (3, 'Patrick Rothfuss')");
            Sql("INSERT into Authors (Id, FullName) VALUES (4, 'V. Anton Spraul')");
            Sql("INSERT into Authors (Id, FullName) VALUES (5, 'Gaius Julius Ceasar')");
            Sql("INSERT into Authors (Id, FullName) VALUES (6, 'John Writer')");
            Sql("INSERT into Authors (Id, FullName) VALUES (7, 'Jane Writer')");
            Sql("SET IDENTITY_INSERT Authors OFF");

            Sql("INSERT into BookAuthors (Book_Id, Author_Id) VALUES (1, 1)");
            Sql("INSERT into BookAuthors (Book_Id, Author_Id) VALUES (2, 2)");
            Sql("INSERT into BookAuthors (Book_Id, Author_Id) VALUES (3, 3)");
            Sql("INSERT into BookAuthors (Book_Id, Author_Id) VALUES (4, 4)");
            Sql("INSERT into BookAuthors (Book_Id, Author_Id) VALUES (5, 5)");
            Sql("INSERT into BookAuthors (Book_Id, Author_Id) VALUES (6, 3)");
            Sql("INSERT into BookAuthors (Book_Id, Author_Id) VALUES (7, 6)");
            Sql("INSERT into BookAuthors (Book_Id, Author_Id) VALUES (7, 7)");
        }

        public override void Down()
        {
        }
    }
}
