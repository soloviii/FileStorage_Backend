using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "004f27b9-2aa1-4d9e-b704-0297892fc584",
                column: "ConcurrencyStamp",
                value: "8b390ba9-8116-4a5e-b65a-175f061a3723");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66b2703e-57fc-42ab-85d7-996ad1c0029b",
                column: "ConcurrencyStamp",
                value: "d0de3622-31a9-4ce5-b6a2-f9d6c66d8117");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2aa8379d-c3f0-47a9-b2f0-631787bb4970",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "f95cc3a0-e8e4-487a-9b1f-6ffb5507116c", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEPY9j9yOQ4KLsYYuv7gVNNT/0RluUAdyFFBykaGQEc7HVncAmnVEe8OcZX6Yzjkelg==", "4246f378-6f40-4fe3-96c2-d2e59716adb5", "admin@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "004f27b9-2aa1-4d9e-b704-0297892fc584",
                column: "ConcurrencyStamp",
                value: "a850e232-c146-4474-a0ec-68eabfa7a391");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66b2703e-57fc-42ab-85d7-996ad1c0029b",
                column: "ConcurrencyStamp",
                value: "cc7072f5-019d-4bac-a771-a4f704b67822");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2aa8379d-c3f0-47a9-b2f0-631787bb4970",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "394bb012-bada-4e5c-b8a6-1a164fea106a", null, null, "AQAAAAEAACcQAAAAENaEL4RSZZ+kt4OkoRv3J3ETFAy7/0bgYvSy5GjwIM4Fjifan32pAJAJGaBObFvxIA==", "f77b71a0-15c0-4add-802c-883fd93d1612", null });
        }
    }
}
