using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc0324b6-5e55-4b66-ad34-3c43644f77d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2573724-09f8-498f-8973-6562cf593b5a");

            migrationBuilder.DeleteData(
                table: "LogItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "88293afd-8974-4d70-8008-27d2a35fd076", null, "Administrator", "ADMINISTRATOR" },
                    { "d5d8ab2b-4d6d-498c-a740-a28a241ba6db", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88293afd-8974-4d70-8008-27d2a35fd076");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5d8ab2b-4d6d-498c-a740-a28a241ba6db");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cc0324b6-5e55-4b66-ad34-3c43644f77d0", null, "User", "USER" },
                    { "e2573724-09f8-498f-8973-6562cf593b5a", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "ApplicationUserId", "CompanyId", "CreatedOn", "Hours", "Make", "Mileage", "Model", "UserId", "Year" },
                values: new object[] { 1, null, 1, new DateTime(2024, 3, 15, 19, 37, 53, 466, DateTimeKind.Utc).AddTicks(9570), null, "Ford", 61000, "F-150", "66b55995-d23f-4b07-ab16-6425b63c603d", 2018 });

            migrationBuilder.InsertData(
                table: "LogItems",
                columns: new[] { "Id", "Closed", "ClosedOn", "CreatedOn", "Discrepency", "UserId", "VehicleId" },
                values: new object[] { 1, false, null, new DateTime(2024, 3, 15, 19, 37, 53, 466, DateTimeKind.Utc).AddTicks(9713), "Rear right hand tire has slow leak.", "66b55995-d23f-4b07-ab16-6425b63c603d", 1 });
        }
    }
}
