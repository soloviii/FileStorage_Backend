using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class removeRequire : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserLimit_UserLimitId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_UserLimit_UserId",
                table: "UserLimit");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserLimitId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserLimitId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "004f27b9-2aa1-4d9e-b704-0297892fc584",
                column: "ConcurrencyStamp",
                value: "a78b4666-21f4-47fc-b74c-59f67d6dfc59");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66b2703e-57fc-42ab-85d7-996ad1c0029b",
                column: "ConcurrencyStamp",
                value: "86b05efb-bccd-442d-aab7-ea415b789d4f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87b68954-9168-4d08-bd8a-a12a5dbc6f70",
                column: "ConcurrencyStamp",
                value: "4b38cf14-fcb4-432d-ac84-93fcf9bd9c66");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2aa8379d-c3f0-47a9-b2f0-631787bb4970",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "689e298e-3d38-4194-8d18-ce3812e1236e", "AQAAAAEAACcQAAAAECgiiVX2we4q5jyC28RZKYffuX99y7Vn1Blyz878PCCamdFGdS4fTXPscKe2c5ZKLg==", "f97ee749-67d2-4a02-a3e4-085941b77cd0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec7c8233-b171-4ce5-a2ca-d612e70f9658",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ed08f2a-49b1-4c99-bb5f-44ce15c1ad3b", "AQAAAAEAACcQAAAAEDIpodCZWSt2rdhs6cPQSECDVIapnDFPS7ZhRiVNbHA+oWANh+j2P9g2/UvBHO0lOA==", "efd49d4a-df50-4378-812b-135ba5f73765" });

            migrationBuilder.CreateIndex(
                name: "IX_UserLimit_UserId",
                table: "UserLimit",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserLimit_UserId",
                table: "UserLimit");

            migrationBuilder.AddColumn<Guid>(
                name: "UserLimitId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
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
        }
    }
}
