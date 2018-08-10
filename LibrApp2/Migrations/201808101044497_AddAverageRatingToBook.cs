namespace LibrApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAverageRatingToBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "AverageRating", c => c.Single(nullable: false));
            AlterColumn("dbo.Reviews", "Rate", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "Rate", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "AverageRating");
        }
    }
}
