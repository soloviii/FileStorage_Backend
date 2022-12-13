using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UserLoginModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b8ff840-5ab8-492a-b4b2-85fbd2a7cec7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee324634-e06c-4fff-bfdd-9cc974a97428");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c03563e3-40b9-449b-ba62-753e69f3c0bc", "4dd48fd3-6a2e-441c-b017-aa8d912544be", "RegisteredUser", "REGISTEREDUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c8618191-fbc4-4642-998f-1a2bb591477a", "41bf32b3-6575-40b0-a758-d760e4ed7282", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c03563e3-40b9-449b-ba62-753e69f3c0bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8618191-fbc4-4642-998f-1a2bb591477a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0b8ff840-5ab8-492a-b4b2-85fbd2a7cec7", "7a61e348-c01c-4b7c-a0c1-c29e44e1a379", "RegisteredUser", "REGISTEREDUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ee324634-e06c-4fff-bfdd-9cc974a97428", "0084a507-bbd2-4491-bef3-3128da6aeed9", "Administrator", "ADMINISTRATOR" });
        }
    }
}
