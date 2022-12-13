using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ChangeUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c03563e3-40b9-449b-ba62-753e69f3c0bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8618191-fbc4-4642-998f-1a2bb591477a");

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f1accf22-e6cb-4f3c-885d-62069d524310", "5597fa97-38b0-400c-a396-ebcc62468aa4", "RegisteredUser", "REGISTEREDUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2d5bd095-08a4-445f-b130-28386cae2631", "d9013c6b-80f5-420b-b6c8-577ad31e6686", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5bd095-08a4-445f-b130-28386cae2631");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1accf22-e6cb-4f3c-885d-62069d524310");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c03563e3-40b9-449b-ba62-753e69f3c0bc", "4dd48fd3-6a2e-441c-b017-aa8d912544be", "RegisteredUser", "REGISTEREDUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c8618191-fbc4-4642-998f-1a2bb591477a", "41bf32b3-6575-40b0-a758-d760e4ed7282", "Administrator", "ADMINISTRATOR" });
        }
    }
}
