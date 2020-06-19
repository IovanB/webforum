using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebForum.Infrastructure.Migrations
{
    public partial class maisumavez : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("06ed4c45-f0a1-497c-a2de-ad8f748eacd7"));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Birthday", "CreatedAt", "Email", "Name", "Password", "UpdatedAt", "UserType" },
                values: new object[] { new Guid("6121e144-2651-4353-8335-baddecf5aff2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 5, 13, 46, 0, 637, DateTimeKind.Local).AddTicks(325), "email@email.com", "Teste", "testetesteteste", new DateTime(2020, 2, 5, 13, 46, 0, 640, DateTimeKind.Local).AddTicks(5197), 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6121e144-2651-4353-8335-baddecf5aff2"));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Birthday", "CreatedAt", "Email", "Name", "Password", "UpdatedAt", "UserType" },
                values: new object[] { new Guid("06ed4c45-f0a1-497c-a2de-ad8f748eacd7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 5, 11, 38, 48, 26, DateTimeKind.Local).AddTicks(4063), "email@email.com", "Teste", "testetesteteste", new DateTime(2020, 2, 5, 11, 38, 48, 30, DateTimeKind.Local).AddTicks(1819), 0 });
        }
    }
}
