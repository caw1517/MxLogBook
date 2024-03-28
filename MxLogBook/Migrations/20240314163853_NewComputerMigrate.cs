using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class NewComputerMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bdd3dc7-44cd-4d9d-9e8b-3cce5c87542a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a7ac33b-728e-4b31-a546-bdbcb6262e26");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c9001c5-0c27-431a-87ec-b614ae4c09f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2d84e88-1b2c-454e-abb3-d7ceef33b6e5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "49aa6b3e-69f0-43e8-851f-6c91316614a7", null, "CompanyAdmin", "COMPANYADMIN" },
                    { "796b9a64-e951-4191-8072-a983d14ab437", null, "Administrator", "ADMINISTRATOR" },
                    { "a17e1230-4667-48db-98f6-16609c346e3f", null, "User", "USER" },
                    { "a97197a7-ce0e-4e37-8be6-ae5297d03693", null, "CompanyUser", "COMPANYUSER" }
                });

            migrationBuilder.UpdateData(
                table: "LogItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 14, 16, 38, 52, 544, DateTimeKind.Utc).AddTicks(6160));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 14, 16, 38, 52, 544, DateTimeKind.Utc).AddTicks(6022));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa6b3e-69f0-43e8-851f-6c91316614a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "796b9a64-e951-4191-8072-a983d14ab437");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a17e1230-4667-48db-98f6-16609c346e3f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a97197a7-ce0e-4e37-8be6-ae5297d03693");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3bdd3dc7-44cd-4d9d-9e8b-3cce5c87542a", null, "User", "USER" },
                    { "7a7ac33b-728e-4b31-a546-bdbcb6262e26", null, "Administrator", "ADMINISTRATOR" },
                    { "8c9001c5-0c27-431a-87ec-b614ae4c09f9", null, "CompanyUser", "COMPANYUSER" },
                    { "b2d84e88-1b2c-454e-abb3-d7ceef33b6e5", null, "CompanyAdmin", "COMPANYADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "LogItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 29, 21, 19, 5, 358, DateTimeKind.Utc).AddTicks(3622));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 29, 21, 19, 5, 358, DateTimeKind.Utc).AddTicks(3516));
        }
    }
}
