namespace Midly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            //@"" to add miltiple line sql
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4fed87cb-8366-482d-92a8-8f0c7a79e9e4', N'guest@vidly.com', 0, N'AI+q3ScBjJhT5zupZ1pp/wR8z+GN2Vjf/jG60VZ4G1rvnlwX515CkSTLFlAMfpyuSg==', N'fec2349e-a721-4752-ba62-371ee946137a', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a02b8fd6-bacb-45b6-8c62-03f595ca6758', N'admin@vidly.com', 0, N'ACijyRf+3oCfdsblXFuWHI5sKOcI2gEd1NPrDhX+GGmKb45jEobrhYahdUNYA0OTJg==', N'bf189836-0a5b-4d66-94a3-271b97f470e8', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e39c5e87-43b6-4c47-80f3-c4a568fa72dd', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a02b8fd6-bacb-45b6-8c62-03f595ca6758', N'e39c5e87-43b6-4c47-80f3-c4a568fa72dd')

");
        }
        
        public override void Down()
        {
        }
    }
}
