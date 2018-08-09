namespace LibrApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReviewsModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(maxLength: 255),
                        Rate = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        UserProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfileId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.UserProfileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.Reviews", "BookId", "dbo.Books");
            DropIndex("dbo.Reviews", new[] { "UserProfileId" });
            DropIndex("dbo.Reviews", new[] { "BookId" });
            DropTable("dbo.Reviews");
        }
    }
}
