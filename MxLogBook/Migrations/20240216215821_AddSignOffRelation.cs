using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddSignOffRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f61fcb34-5394-48bd-8caa-a25cc6d6d71a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcad6f7b-9245-40b7-86eb-25e55332612a");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95c0491e-de0e-459b-a3b0-ca302ed48363");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d0c6bde-fc49-4849-abed-7e8f41624031");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f61fcb34-5394-48bd-8caa-a25cc6d6d71a", null, "Administrator", "ADMINISTRATOR" },
                    { "fcad6f7b-9245-40b7-86eb-25e55332612a", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "LogItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 16, 21, 55, 54, 560, DateTimeKind.Utc).AddTicks(6748));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 16, 21, 55, 54, 560, DateTimeKind.Utc).AddTicks(6627));
        }
    }
}
