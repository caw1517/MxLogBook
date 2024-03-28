using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedNewRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SignOffs_AspNetUsers_UserId",
                table: "SignOffs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a98e13d7-a7e9-49c0-af67-5d4217088fc8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3fff9ff-1035-4262-b317-a6873c13d23d");

            migrationBuilder.AlterColumn<string>(
                name: "WorkPerformed",
                table: "SignOffs",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SignOffs",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5735e1a9-0d7e-4420-984c-c5f4e167a405", null, "CompanyUser", "COMPANYUSER" },
                    { "dca342d5-c876-48b5-994b-e6cc16b9fa69", null, "User", "USER" },
                    { "e1a8f6f9-2c56-49af-9eab-5f7ed99447ab", null, "Administrator", "ADMINISTRATOR" },
                    { "f763167c-f7c3-4197-bb4b-227f6971e7f3", null, "CompanyAdmin", "COMPANYADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "LogItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 28, 21, 23, 20, 668, DateTimeKind.Utc).AddTicks(9476));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 28, 21, 23, 20, 668, DateTimeKind.Utc).AddTicks(9393));

            migrationBuilder.AddForeignKey(
                name: "FK_SignOffs_AspNetUsers_UserId",
                table: "SignOffs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SignOffs_AspNetUsers_UserId",
                table: "SignOffs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5735e1a9-0d7e-4420-984c-c5f4e167a405");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dca342d5-c876-48b5-994b-e6cc16b9fa69");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1a8f6f9-2c56-49af-9eab-5f7ed99447ab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f763167c-f7c3-4197-bb4b-227f6971e7f3");

            migrationBuilder.AlterColumn<string>(
                name: "WorkPerformed",
                table: "SignOffs",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SignOffs",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a98e13d7-a7e9-49c0-af67-5d4217088fc8", null, "User", "USER" },
                    { "d3fff9ff-1035-4262-b317-a6873c13d23d", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "LogItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 16, 21, 59, 25, 566, DateTimeKind.Utc).AddTicks(5986));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 16, 21, 59, 25, 566, DateTimeKind.Utc).AddTicks(5865));

            migrationBuilder.AddForeignKey(
                name: "FK_SignOffs_AspNetUsers_UserId",
                table: "SignOffs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
