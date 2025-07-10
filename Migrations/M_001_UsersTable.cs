using FluentMigrator;

namespace BasicApi.Migrations
{
    [Migration(001)]
    public class M_001_UsersTable : Migration
    {
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(100).NotNullable()
                .WithColumn("Email").AsString(200).NotNullable()
                .WithColumn("PasswordHash").AsString(100).NotNullable()
                .WithColumn("CreatedAt").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);

            Create.Index("IX_Users_Email")
                .OnTable("Users")
                .OnColumn("Email")
                .Unique();
        }

        public override void Down()
        {
            Delete.Table("Users");
        }
    }
}