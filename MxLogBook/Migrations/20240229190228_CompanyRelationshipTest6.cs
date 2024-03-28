using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class CompanyRelationshipTest6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "55ada520-676a-451e-a05c-ea6fbb2900e4", null, "CompanyAdmin", "COMPANYADMIN" },
                    { "6003d622-2f59-488f-af20-131ee6380a05", null, "CompanyUser", "COMPANYUSER" },
                    { "65f12336-1252-4a50-9a68-b3ddb1e900de", null, "User", "USER" },
                    { "b9a68ac9-f3a2-4ef6-a7f5-a76fa69e7b84", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "LogItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 29, 19, 2, 27, 888, DateTimeKind.Utc).AddTicks(9994));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 29, 19, 2, 27, 888, DateTimeKind.Utc).AddTicks(9905));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55ada520-676a-451e-a05c-ea6fbb2900e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6003d622-2f59-488f-af20-131ee6380a05");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65f12336-1252-4a50-9a68-b3ddb1e900de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9a68ac9-f3a2-4ef6-a7f5-a76fa69e7b84");

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
    }
}
