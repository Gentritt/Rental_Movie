namespace Rental_Movie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N' ', N'gentselimi7@gmail.com', 0, N'ANSQZqQO8PtRhqC9uoN4Lyt09obJRvHZD0Pbnn+6cntd+ZIEhMh2kxaMvMlJeRLYZQ==', N'284d864e-a220-4125-8ee2-353ad9b31d3c', N'044352799', 0, 0, NULL, 1, 0, N'gentselimi7@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5ff6b53f-eeac-46b4-a944-6ff128e12a47', N'admin@admin.com', 0, N'AKxu5fWfPAs7ZDSnS1omgrYIVaMcrsDL+Af5pTpKtjoZHpqWIwbdmB4uEHxchxDr9w==', N'd615d156-8645-4a34-ad34-29f5e02580c1', N'04435278222', 0, 0, NULL, 1, 0, N'admin@admin.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'79c87b9e-e34a-4224-be1a-f5763af144e8', N'guest@movie.com', 0, N'ABSVTrXKsbj9tHxZ607XvtrDqTjlV1lp4Iq0xsbnSUNy9HKQi5A6egPdpx+/PhhsTA==', N'e0d36664-fe57-4517-94d2-a009de2fce8b', N'044352788', 0, 0, NULL, 1, 0, N'guest@movie.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a888c241-75b2-47ba-a7f8-d89b6fffa812', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5ff6b53f-eeac-46b4-a944-6ff128e12a47', N'a888c241-75b2-47ba-a7f8-d89b6fffa812')

");
        }
        
        public override void Down()
        {
        }
    }
}
