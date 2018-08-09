namespace LibrApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'42045f57-49a5-46b6-bbc8-9299006c3390', N'admin@admin.com', 0, N'AND9gYDjnJCI/In4xB9LK3nlWufMQ+7ZIuhbGLSBVcna85FPXz8GgGKajayQ+t9mmg==', N'7ec9f717-edc3-4736-89af-ca8c8ac32407', NULL, 0, 0, NULL, 1, 0, N'admin@admin.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bda68cb3-1509-421e-9aa1-eb146827a48b', N'user@user.com', 0, N'AN5pHp+phGP7jnmwdxVtH4jpDJCplDtfCvv7k5SQ+nqa+2gMCQi4gyeLHnBWt1aZ/A==', N'57f6a55b-ad99-4de5-87e0-152c875dbabd', NULL, 0, 0, NULL, 1, 0, N'user@user.com')

SET IDENTITY_INSERT [dbo].[UserProfiles] ON
INSERT INTO [dbo].[UserProfiles] ([Id], [AspNetUserId], [Username], [User_Id]) VALUES (3, N'42045f57-49a5-46b6-bbc8-9299006c3390', N'admin', NULL)
INSERT INTO [dbo].[UserProfiles] ([Id], [AspNetUserId], [Username], [User_Id]) VALUES (4, N'bda68cb3-1509-421e-9aa1-eb146827a48b', N'user', NULL)
SET IDENTITY_INSERT [dbo].[UserProfiles] OFF

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c59dddf9-0443-4c29-bb61-fbbadbf7e015', N'Admin')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'42045f57-49a5-46b6-bbc8-9299006c3390', N'c59dddf9-0443-4c29-bb61-fbbadbf7e015')");
        }
        
        public override void Down()
        {
        }
    }
}
