using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ChangeOnModelCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87b68954-9168-4d08-bd8a-a12a5dbc6f70",
                column: "ConcurrencyStamp",
                value: "d1fbaa87-0d08-4ad2-bb8d-761d1a49c333");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "66b2703e-57fc-42ab-85d7-996ad1c0029b", "f8f7918d-1831-4e62-843a-8d46fe5bf001", "RegisteredUser", "REGISTEREDUSER" },
                    { "004f27b9-2aa1-4d9e-b704-0297892fc584", "5911860e-7d3e-45df-8d85-feccfb0b9393", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec7c8233-b171-4ce5-a2ca-d612e70f9658",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7d263f5-6e4e-45c2-8eba-4657787a7d48", "AQAAAAEAACcQAAAAENCwZeouveI2Zb6aDYiLQPZSyVWTBj31RcLNjchcNDPVNDDFIcUQp0WqxrC+6cT2Tw==", "d42b611e-f887-45f0-ba48-0fe34c1d7026" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsDisabled", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "NumberOfFiles", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SumOfFilesSize", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2aa8379d-c3f0-47a9-b2f0-631787bb4970", 0, "9506c30a-0151-4ab2-9b05-26e3aa4dfcfc", "admin@gmail.com", false, "admin", false, "admin", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", 0, "AQAAAAEAACcQAAAAEEtqhkovvUlAXubAbX8M8lPT1UA/oKLcufsRyRzpyu5LlAlzxJ7ajiGz/94r+7R9Sg==", null, false, "d1720aed-b2d4-417b-84d5-453475c9e0c7", 0L, false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "2aa8379d-c3f0-47a9-b2f0-631787bb4970", "004f27b9-2aa1-4d9e-b704-0297892fc584" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66b2703e-57fc-42ab-85d7-996ad1c0029b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "2aa8379d-c3f0-47a9-b2f0-631787bb4970", "004f27b9-2aa1-4d9e-b704-0297892fc584" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "004f27b9-2aa1-4d9e-b704-0297892fc584");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2aa8379d-c3f0-47a9-b2f0-631787bb4970");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87b68954-9168-4d08-bd8a-a12a5dbc6f70",
                column: "ConcurrencyStamp",
                value: "7cae4ea4-cbbd-4612-bb79-496020323e40");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec7c8233-b171-4ce5-a2ca-d612e70f9658",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "902a0643-9ac2-4085-af12-e0aaae038cc0", "AQAAAAEAACcQAAAAEN2uoLJAe+0FRx1hWNZyPZN+I+K9AzCwxdWfRXu5wO0jFLEAA9GYmNiXbJcBBfxHmg==", "35240c8b-5d45-4dab-8a6c-d2d019a0858a" });
        }
    }
}
