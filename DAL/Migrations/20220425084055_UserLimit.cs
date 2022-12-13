using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UserLimit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfFiles",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "SumOfFilesSize",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "UserLimit",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MaxFilesNumber = table.Column<int>(nullable: true),
                    MaxFileSize = table.Column<long>(nullable: true),
                    MaxStorageSize = table.Column<long>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLimit", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "004f27b9-2aa1-4d9e-b704-0297892fc584",
                column: "ConcurrencyStamp",
                value: "8704b43c-d301-4282-bc31-eecd36bd86c7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66b2703e-57fc-42ab-85d7-996ad1c0029b",
                column: "ConcurrencyStamp",
                value: "fbf6eaaf-bb32-4627-b2aa-120f90934e16");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2aa8379d-c3f0-47a9-b2f0-631787bb4970",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7338d37-c186-4cff-9985-89bf5937ae0d", "AQAAAAEAACcQAAAAELIKZ3uydwFLZde2gu3lUBjVvugs9iW6xOy1CG/YCrRA0JWewnJkj44yn+e3VFWCAw==", "21cc68bf-7abb-4af8-98cd-241ca7e3234e" });

            migrationBuilder.InsertData(
                table: "UserLimit",
                columns: new[] { "Id", "MaxFileSize", "MaxFilesNumber", "MaxStorageSize", "UserId" },
                values: new object[] { new Guid("0b35a2fa-6557-4bdf-9beb-409febcb6bae"), 5242880L, 10, 52428800L, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLimit");

            migrationBuilder.DropColumn(
                name: "NumberOfFiles",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SumOfFilesSize",
                table: "AspNetUsers");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f95cc3a0-e8e4-487a-9b1f-6ffb5507116c", "AQAAAAEAACcQAAAAEPY9j9yOQ4KLsYYuv7gVNNT/0RluUAdyFFBykaGQEc7HVncAmnVEe8OcZX6Yzjkelg==", "4246f378-6f40-4fe3-96c2-d2e59716adb5" });
        }
    }
}
