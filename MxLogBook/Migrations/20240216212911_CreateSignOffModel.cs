using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class CreateSignOffModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "398bf48e-7d76-4f42-bdc4-338706d1ff00");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b4b0c3e-4221-4465-a70a-bf74133459a1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01a44da2-4852-4c2a-b0aa-29897e75dd57", null, "User", "USER" },
                    { "0add4abb-9e3c-4ca2-95d2-3ebeb164cc50", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "log_items",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 16, 21, 29, 10, 360, DateTimeKind.Utc).AddTicks(5604));

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 16, 21, 29, 10, 360, DateTimeKind.Utc).AddTicks(5504));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01a44da2-4852-4c2a-b0aa-29897e75dd57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0add4abb-9e3c-4ca2-95d2-3ebeb164cc50");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "398bf48e-7d76-4f42-bdc4-338706d1ff00", null, "User", "USER" },
                    { "5b4b0c3e-4221-4465-a70a-bf74133459a1", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "log_items",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 15, 18, 50, 50, 995, DateTimeKind.Utc).AddTicks(4803));

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 15, 18, 50, 50, 995, DateTimeKind.Utc).AddTicks(4718));
        }
    }
}
