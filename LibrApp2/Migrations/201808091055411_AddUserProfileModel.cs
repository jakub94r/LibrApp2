namespace LibrApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserProfileModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AspNetUserId = c.String(),
                        Username = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Books", "UserProfile_Id", c => c.Int());
            CreateIndex("dbo.Books", "UserProfile_Id");
            AddForeignKey("dbo.Books", "UserProfile_Id", "dbo.UserProfiles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfiles", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Books", "UserProfile_Id", "dbo.UserProfiles");
            DropIndex("dbo.UserProfiles", new[] { "User_Id" });
            DropIndex("dbo.Books", new[] { "UserProfile_Id" });
            DropColumn("dbo.Books", "UserProfile_Id");
            DropTable("dbo.UserProfiles");
        }
    }
}
