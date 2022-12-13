using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5bd095-08a4-445f-b130-28386cae2631");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1accf22-e6cb-4f3c-885d-62069d524310");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "66b2703e-57fc-42ab-85d7-996ad1c0029b", "cc7072f5-019d-4bac-a771-a4f704b67822", "RegisteredUser", "REGISTEREDUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "004f27b9-2aa1-4d9e-b704-0297892fc584", "a850e232-c146-4474-a0ec-68eabfa7a391", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsDisabled", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2aa8379d-c3f0-47a9-b2f0-631787bb4970", 0, "394bb012-bada-4e5c-b8a6-1a164fea106a", "admin@gmail.com", false, "admin", false, "admin", false, null, null, null, "AQAAAAEAACcQAAAAENaEL4RSZZ+kt4OkoRv3J3ETFAy7/0bgYvSy5GjwIM4Fjifan32pAJAJGaBObFvxIA==", null, false, "f77b71a0-15c0-4add-802c-883fd93d1612", false, null });

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f1accf22-e6cb-4f3c-885d-62069d524310", "5597fa97-38b0-400c-a396-ebcc62468aa4", "RegisteredUser", "REGISTEREDUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2d5bd095-08a4-445f-b130-28386cae2631", "d9013c6b-80f5-420b-b6c8-577ad31e6686", "Administrator", "ADMINISTRATOR" });
        }
    }
}
