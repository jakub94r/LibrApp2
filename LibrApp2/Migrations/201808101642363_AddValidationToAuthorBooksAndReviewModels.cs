namespace LibrApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValidationToAuthorBooksAndReviewModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "FullName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Books", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Name", c => c.String());
            AlterColumn("dbo.Authors", "FullName", c => c.String());
        }
    }
}
