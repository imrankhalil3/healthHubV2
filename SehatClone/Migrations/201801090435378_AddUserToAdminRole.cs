namespace SehatClone.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddUserToAdminRole : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'022724e1-dff9-4424-ab0d-edd3f13b32c3', N'asd@gmail.com', 0, N'ANIlVkNvwLj8CXfHkzoxpCKhidqc9lGziMwlAm9VUPe0Ris+/Xjs3aW2WOVL1v8vCQ==', N'fd7970d5-00c4-4ae7-9773-3734df40f5a6', NULL, 0, 0, NULL, 1, 0, N'asd@gmail.com')");
            Sql("INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'476eac01-2414-4b91-b86b-11d5d5437a64', N'admin@gmail.com', 0, N'AKsTGxDQJS8gFuQzv0ds7kPhvUibMXlWuKRLZTw534gJLNIqvRON5a/AVJmMAnCcvQ==', N'3876346c-e5e3-47cc-9ab3-6df04a90be9b', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')");
            Sql("INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'4bebdcf5-3496-465a-ae9e-a9a18822f3f2', N'user@gmail.com', 0, N'ACd1O3mjWQjYtrLxVmU6J0xoIDn1toazgOB2qHzjPmrYw1x+ERvC4vHiV0nmC5jViA==', N'099d5a56-edc9-4b9b-9d74-9b2d22580e35', NULL, 0, 0, NULL, 1, 0, N'user@gmail.com')");
            Sql("INSERT INTO AspNetUserRoles values ('476eac01-2414-4b91-b86b-11d5d5437a64', 1)");
        }

        public override void Down()
        {
            Sql("Delete From AspNetUserRoles WHERE UserId = '476eac01-2414-4b91-b86b-11d5d5437a64' and RoleId = 1");

        }
    }
}