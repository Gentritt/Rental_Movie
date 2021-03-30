namespace Rental_Movie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'71c678eb-2f54-4b69-9aaa-2dc22a99b039', N'guest@movie.com', 0, N'AKYabY8R/M6g5oAtwiAeSp50bVtgJAVkD/3mh8CdXKMVpJ+wAuc5Txk5TC8StK6i1w==', N'2507390e-f2a9-4303-b3ea-21d17561e586', N'04435278222', 0, 0, NULL, 1, 0, N'guest@movie.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'91858a2f-6b4e-42dc-bd23-eda60a6e8e28', N'admin@admin.com', 0, N'APIbcgnTHGm6JVAsTGuFaRrXg1q8xoWotGIe/xWvNMCjW0tuNDYg+kSrKcKrq5aHQg==', N'9f918967-5f9c-44e7-b2ba-ce18da0b1a95', N'04435278222', 0, 0, NULL, 1, 0, N'admin@admin.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ff7c67d1-fdee-46bd-aeef-3357e5ca9703', N'Admin')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'91858a2f-6b4e-42dc-bd23-eda60a6e8e28', N'ff7c67d1-fdee-46bd-aeef-3357e5ca9703')

");
        }
        
        public override void Down()
        {
        }
    }
}
