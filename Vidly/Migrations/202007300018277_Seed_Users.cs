namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seed_Users : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9bdc0876-c873-4f93-a831-e66668bac483', N'guest1@vidly.com', 0, N'AJ0EIqRKX3t+QY4Q6XoWU1OgVKHaTjck3Yy6gSeeWrPDyxsRM5azYHIpkFbS3c2U7w==', N'2d8533fb-299d-4a6d-a9a4-7d6e30095c0f', NULL, 0, 0, NULL, 1, 0, N'guest1@vidly.com');
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9dd3c601-f938-4811-8765-86487fd11bbb', N'manager@vidly.com', 0, N'AInidn1Xi9ckFm9dt6LlP2bD9I7d666f7NMUVseI5brKtExoaR+jV7ii5rVmH31jSQ==', N'cc10fee4-1863-407a-bf29-2a08e6621813', NULL, 0, 0, NULL, 1, 0, N'manager@vidly.com');

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'56a9d91f-e045-4f43-b96d-d8c3c90a28d4', N'Manager');

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9dd3c601-f938-4811-8765-86487fd11bbb', N'56a9d91f-e045-4f43-b96d-d8c3c90a28d4');       
            ");
        }
        
        public override void Down()
        {
        }
    }
}
