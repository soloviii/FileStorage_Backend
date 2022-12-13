using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class changeUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserLimit",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Files",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "UserLimitId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "004f27b9-2aa1-4d9e-b704-0297892fc584",
                column: "ConcurrencyStamp",
                value: "f7e629c0-203b-4392-adc8-2f7e77dfeb04");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66b2703e-57fc-42ab-85d7-996ad1c0029b",
                column: "ConcurrencyStamp",
                value: "387a8ed9-4344-494c-93ca-fbda326b7b54");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87b68954-9168-4d08-bd8a-a12a5dbc6f70",
                column: "ConcurrencyStamp",
                value: "b941d2e3-219e-484d-b5e3-bf9f68ea8563");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2aa8379d-c3f0-47a9-b2f0-631787bb4970",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "440c9404-d515-45a8-a6f3-8099eeeaed99", "AQAAAAEAACcQAAAAEDDt0ibp7rxwXtSKluahsd1c02pASX8YiT2R6+P/r3UGxxcuPWvRZ3FuR/31GeOLrw==", "f37e5554-3ac4-4de1-9f12-5cc91356819e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec7c8233-b171-4ce5-a2ca-d612e70f9658",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10f71fe0-c2b1-4041-baae-8a6a9ee36b6f", "AQAAAAEAACcQAAAAEKwIlhw6bvWSBAhHk9FfxTJ8ArxzK0Gpv1fEhE+ZSfQB42EVeJJvno/mtTVggKN62A==", "8f6e81aa-4007-4ab8-a3f0-b70d4c4dd4c2" });

            migrationBuilder.CreateIndex(
                name: "IX_UserLimit_UserId",
                table: "UserLimit",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_UserId",
                table: "Files",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserLimitId",
                table: "AspNetUsers",
                column: "UserLimitId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserLimit_UserLimitId",
                table: "AspNetUsers",
                column: "UserLimitId",
                principalTable: "UserLimit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_AspNetUsers_UserId",
                table: "Files",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLimit_AspNetUsers_UserId",
                table: "UserLimit",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserLimit_UserLimitId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_AspNetUsers_UserId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLimit_AspNetUsers_UserId",
                table: "UserLimit");

            migrationBuilder.DropIndex(
                name: "IX_UserLimit_UserId",
                table: "UserLimit");

            migrationBuilder.DropIndex(
                name: "IX_Files_UserId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserLimitId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserLimitId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UserLimit",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Files",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "004f27b9-2aa1-4d9e-b704-0297892fc584",
                column: "ConcurrencyStamp",
                value: "5911860e-7d3e-45df-8d85-feccfb0b9393");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66b2703e-57fc-42ab-85d7-996ad1c0029b",
                column: "ConcurrencyStamp",
                value: "f8f7918d-1831-4e62-843a-8d46fe5bf001");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87b68954-9168-4d08-bd8a-a12a5dbc6f70",
                column: "ConcurrencyStamp",
                value: "d1fbaa87-0d08-4ad2-bb8d-761d1a49c333");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2aa8379d-c3f0-47a9-b2f0-631787bb4970",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9506c30a-0151-4ab2-9b05-26e3aa4dfcfc", "AQAAAAEAACcQAAAAEEtqhkovvUlAXubAbX8M8lPT1UA/oKLcufsRyRzpyu5LlAlzxJ7ajiGz/94r+7R9Sg==", "d1720aed-b2d4-417b-84d5-453475c9e0c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec7c8233-b171-4ce5-a2ca-d612e70f9658",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7d263f5-6e4e-45c2-8eba-4657787a7d48", "AQAAAAEAACcQAAAAENCwZeouveI2Zb6aDYiLQPZSyVWTBj31RcLNjchcNDPVNDDFIcUQp0WqxrC+6cT2Tw==", "d42b611e-f887-45f0-ba48-0fe34c1d7026" });
        }
    }
}
