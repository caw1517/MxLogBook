using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class DbSetChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06ea4434-9299-4b58-b754-7680d4da8247");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55a99274-98b3-42e6-a879-4e4abf0ee5a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "831bc48c-951e-4ded-9223-b1223ef257c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c71607f0-c8b6-4b19-8672-8f2210a0e54e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0503f759-0b07-40f7-bfec-e2231c6057f5", null, "User", "USER" },
                    { "382eee70-bc51-4ff7-beae-b6483101a44b", null, "Administrator", "ADMINISTRATOR" },
                    { "49e5fc5f-3925-407b-af8c-cd030ce439e2", null, "CompanyAdmin", "COMPANYADMIN" },
                    { "787e99be-374c-4404-aa78-d8394b69fa76", null, "CompanyUser", "COMPANYUSER" }
                });

            migrationBuilder.UpdateData(
                table: "LogItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 29, 20, 54, 51, 915, DateTimeKind.Utc).AddTicks(2338));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 29, 20, 54, 51, 915, DateTimeKind.Utc).AddTicks(2240));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0503f759-0b07-40f7-bfec-e2231c6057f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "382eee70-bc51-4ff7-beae-b6483101a44b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49e5fc5f-3925-407b-af8c-cd030ce439e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "787e99be-374c-4404-aa78-d8394b69fa76");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06ea4434-9299-4b58-b754-7680d4da8247", null, "CompanyAdmin", "COMPANYADMIN" },
                    { "55a99274-98b3-42e6-a879-4e4abf0ee5a6", null, "User", "USER" },
                    { "831bc48c-951e-4ded-9223-b1223ef257c4", null, "CompanyUser", "COMPANYUSER" },
                    { "c71607f0-c8b6-4b19-8672-8f2210a0e54e", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "LogItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 29, 20, 41, 29, 595, DateTimeKind.Utc).AddTicks(2446));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 29, 20, 41, 29, 595, DateTimeKind.Utc).AddTicks(2298));
        }
    }
}
