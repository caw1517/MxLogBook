using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class LogItemUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad688228-bb74-4275-9c68-e1ef4bab05b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c985a73a-fa6b-4af1-8e73-3848970f9b5e");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "log_items",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "93d93984-a20f-4925-9a02-702d8c005793", null, "User", "USER" },
                    { "ca2b9f76-9845-4f84-a627-b4950481ddd6", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "log_items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UserId" },
                values: new object[] { new DateTime(2024, 2, 15, 18, 50, 17, 966, DateTimeKind.Utc).AddTicks(4545), null });

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 15, 18, 50, 17, 966, DateTimeKind.Utc).AddTicks(4460));

            migrationBuilder.CreateIndex(
                name: "IX_log_items_UserId",
                table: "log_items",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_log_items_AspNetUsers_UserId",
                table: "log_items",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_log_items_AspNetUsers_UserId",
                table: "log_items");

            migrationBuilder.DropIndex(
                name: "IX_log_items_UserId",
                table: "log_items");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93d93984-a20f-4925-9a02-702d8c005793");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca2b9f76-9845-4f84-a627-b4950481ddd6");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "log_items");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad688228-bb74-4275-9c68-e1ef4bab05b1", null, "User", "USER" },
                    { "c985a73a-fa6b-4af1-8e73-3848970f9b5e", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "log_items",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 15, 17, 59, 48, 486, DateTimeKind.Utc).AddTicks(7994));

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 15, 17, 59, 48, 486, DateTimeKind.Utc).AddTicks(7873));
        }
    }
}
