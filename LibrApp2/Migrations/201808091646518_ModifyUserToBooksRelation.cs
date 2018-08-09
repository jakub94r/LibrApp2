namespace LibrApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyUserToBooksRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "UserProfile_Id", "dbo.UserProfiles");
            DropIndex("dbo.Books", new[] { "UserProfile_Id" });
            CreateTable(
                "dbo.UserProfileBooks",
                c => new
                    {
                        UserProfile_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserProfile_Id, t.Book_Id })
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.UserProfile_Id)
                .Index(t => t.Book_Id);
            
            DropColumn("dbo.Books", "UserProfile_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "UserProfile_Id", c => c.Int());
            DropForeignKey("dbo.UserProfileBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.UserProfileBooks", "UserProfile_Id", "dbo.UserProfiles");
            DropIndex("dbo.UserProfileBooks", new[] { "Book_Id" });
            DropIndex("dbo.UserProfileBooks", new[] { "UserProfile_Id" });
            DropTable("dbo.UserProfileBooks");
            CreateIndex("dbo.Books", "UserProfile_Id");
            AddForeignKey("dbo.Books", "UserProfile_Id", "dbo.UserProfiles", "Id");
        }
    }
}
