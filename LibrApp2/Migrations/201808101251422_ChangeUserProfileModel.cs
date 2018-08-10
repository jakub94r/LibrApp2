namespace LibrApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserProfileModel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UserProfiles", new[] { "User_Id" });
            DropColumn("dbo.UserProfiles", "AspNetUserId");
            RenameColumn(table: "dbo.UserProfiles", name: "User_Id", newName: "AspNetUserId");
            AlterColumn("dbo.UserProfiles", "AspNetUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserProfiles", "AspNetUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserProfiles", new[] { "AspNetUserId" });
            AlterColumn("dbo.UserProfiles", "AspNetUserId", c => c.String());
            RenameColumn(table: "dbo.UserProfiles", name: "AspNetUserId", newName: "User_Id");
            AddColumn("dbo.UserProfiles", "AspNetUserId", c => c.String());
            CreateIndex("dbo.UserProfiles", "User_Id");
        }
    }
}
