using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class CompanyRelationshipTest3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02425bb9-9e06-4eeb-b868-9dbe05099af6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e1293cb-bf74-4d4a-bb1a-a19ef5e2a19e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b18cf1a-506f-41cc-84f2-1d1e57fe2c2c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "641abba5-ea43-4eb2-adb4-955f6380dd1f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2067c1fc-8664-4656-8af0-0b8318232842", null, "CompanyUser", "COMPANYUSER" },
                    { "25eaa773-3e21-4f38-ab54-9261988ea4e1", null, "CompanyAdmin", "COMPANYADMIN" },
                    { "320a61c3-9621-49c5-b206-ec422fc8b86d", null, "User", "USER" },
                    { "de55a371-f0d5-4831-af31-b4a2da2c5f7a", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "LogItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 29, 18, 7, 20, 472, DateTimeKind.Utc).AddTicks(6925));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 29, 18, 7, 20, 472, DateTimeKind.Utc).AddTicks(6844));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2067c1fc-8664-4656-8af0-0b8318232842");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25eaa773-3e21-4f38-ab54-9261988ea4e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "320a61c3-9621-49c5-b206-ec422fc8b86d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de55a371-f0d5-4831-af31-b4a2da2c5f7a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02425bb9-9e06-4eeb-b868-9dbe05099af6", null, "User", "USER" },
                    { "0e1293cb-bf74-4d4a-bb1a-a19ef5e2a19e", null, "Administrator", "ADMINISTRATOR" },
                    { "5b18cf1a-506f-41cc-84f2-1d1e57fe2c2c", null, "CompanyAdmin", "COMPANYADMIN" },
                    { "641abba5-ea43-4eb2-adb4-955f6380dd1f", null, "CompanyUser", "COMPANYUSER" }
                });

            migrationBuilder.UpdateData(
                table: "LogItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 29, 18, 4, 26, 114, DateTimeKind.Utc).AddTicks(7230));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 29, 18, 4, 26, 114, DateTimeKind.Utc).AddTicks(7147));
        }
    }
}
