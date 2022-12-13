using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class SuperAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87b68954-9168-4d08-bd8a-a12a5dbc6f70", "7cae4ea4-cbbd-4612-bb79-496020323e40", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsDisabled", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "NumberOfFiles", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SumOfFilesSize", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ec7c8233-b171-4ce5-a2ca-d612e70f9658", 0, "902a0643-9ac2-4085-af12-e0aaae038cc0", "super@gmail.com", false, "super", false, "super", false, null, "SUPER@GMAIL.COM", "SUPER@GMAIL.COM", 0, "AQAAAAEAACcQAAAAEN2uoLJAe+0FRx1hWNZyPZN+I+K9AzCwxdWfRXu5wO0jFLEAA9GYmNiXbJcBBfxHmg==", null, false, "35240c8b-5d45-4dab-8a6c-d2d019a0858a", 0L, false, "super@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "ec7c8233-b171-4ce5-a2ca-d612e70f9658", "87b68954-9168-4d08-bd8a-a12a5dbc6f70" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "ec7c8233-b171-4ce5-a2ca-d612e70f9658", "87b68954-9168-4d08-bd8a-a12a5dbc6f70" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87b68954-9168-4d08-bd8a-a12a5dbc6f70");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec7c8233-b171-4ce5-a2ca-d612e70f9658");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "66b2703e-57fc-42ab-85d7-996ad1c0029b", "fbf6eaaf-bb32-4627-b2aa-120f90934e16", "RegisteredUser", "REGISTEREDUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "004f27b9-2aa1-4d9e-b704-0297892fc584", "8704b43c-d301-4282-bc31-eecd36bd86c7", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsDisabled", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "NumberOfFiles", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SumOfFilesSize", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2aa8379d-c3f0-47a9-b2f0-631787bb4970", 0, "c7338d37-c186-4cff-9985-89bf5937ae0d", "admin@gmail.com", false, "admin", false, "admin", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", 0, "AQAAAAEAACcQAAAAELIKZ3uydwFLZde2gu3lUBjVvugs9iW6xOy1CG/YCrRA0JWewnJkj44yn+e3VFWCAw==", null, false, "21cc68bf-7abb-4af8-98cd-241ca7e3234e", 0L, false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "2aa8379d-c3f0-47a9-b2f0-631787bb4970", "004f27b9-2aa1-4d9e-b704-0297892fc584" });
        }
    }
}
