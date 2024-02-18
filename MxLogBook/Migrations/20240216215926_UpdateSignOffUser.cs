using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSignOffUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SignOffs_AspNetUsers_UserId1",
                table: "SignOffs");

            migrationBuilder.DropIndex(
                name: "IX_SignOffs_UserId1",
                table: "SignOffs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95c0491e-de0e-459b-a3b0-ca302ed48363");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d0c6bde-fc49-4849-abed-7e8f41624031");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "SignOffs");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SignOffs",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

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

            migrationBuilder.CreateIndex(
                name: "IX_SignOffs_UserId",
                table: "SignOffs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SignOffs_AspNetUsers_UserId",
                table: "SignOffs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SignOffs_AspNetUsers_UserId",
                table: "SignOffs");

            migrationBuilder.DropIndex(
                name: "IX_SignOffs_UserId",
                table: "SignOffs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a98e13d7-a7e9-49c0-af67-5d4217088fc8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3fff9ff-1035-4262-b317-a6873c13d23d");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "SignOffs",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "SignOffs",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "95c0491e-de0e-459b-a3b0-ca302ed48363", null, "Administrator", "ADMINISTRATOR" },
                    { "9d0c6bde-fc49-4849-abed-7e8f41624031", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "LogItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 16, 21, 58, 20, 844, DateTimeKind.Utc).AddTicks(9013));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 16, 21, 58, 20, 844, DateTimeKind.Utc).AddTicks(8892));

            migrationBuilder.CreateIndex(
                name: "IX_SignOffs_UserId1",
                table: "SignOffs",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SignOffs_AspNetUsers_UserId1",
                table: "SignOffs",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
