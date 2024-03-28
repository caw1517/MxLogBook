using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InviteToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53d56191-929c-497e-8ef6-124f2872e5c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81113bba-860e-4dd6-adb2-393fa249735c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2a83f2a-74c5-4645-9cfb-98864126e9a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbd028ff-fa3a-429e-ab71-0c577a170c25");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "395ac8f2-1088-4410-be72-061eec5c8463", null, "CompanyAdmin", "COMPANYADMIN" },
                    { "408e331e-02fb-4cef-b78e-5a44c68b9675", null, "Administrator", "ADMINISTRATOR" },
                    { "b3b88b73-0896-43b7-b3e9-630145ad2b19", null, "User", "USER" },
                    { "b82cb2aa-8eb7-4863-981c-015154b93d56", null, "CompanyUser", "COMPANYUSER" }
                });

            migrationBuilder.UpdateData(
                table: "LogItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 29, 13, 21, 20, 754, DateTimeKind.Utc).AddTicks(3941));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 29, 13, 21, 20, 754, DateTimeKind.Utc).AddTicks(3860));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "395ac8f2-1088-4410-be72-061eec5c8463");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "408e331e-02fb-4cef-b78e-5a44c68b9675");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3b88b73-0896-43b7-b3e9-630145ad2b19");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b82cb2aa-8eb7-4863-981c-015154b93d56");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "53d56191-929c-497e-8ef6-124f2872e5c1", null, "Administrator", "ADMINISTRATOR" },
                    { "81113bba-860e-4dd6-adb2-393fa249735c", null, "CompanyUser", "COMPANYUSER" },
                    { "b2a83f2a-74c5-4645-9cfb-98864126e9a0", null, "CompanyAdmin", "COMPANYADMIN" },
                    { "dbd028ff-fa3a-429e-ab71-0c577a170c25", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "LogItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 28, 21, 51, 22, 401, DateTimeKind.Utc).AddTicks(5132));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 28, 21, 51, 22, 401, DateTimeKind.Utc).AddTicks(5024));
        }
    }
}
