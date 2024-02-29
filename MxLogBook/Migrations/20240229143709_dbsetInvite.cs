using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class dbsetInvite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Invites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TokenNumber = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    CompanyId = table.Column<int>(type: "integer", nullable: false),
                    IsValidToken = table.Column<bool>(type: "boolean", nullable: false),
                    ExpDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invites", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ad2fe29-fc9d-442c-a21b-3e6cee5360b1", null, "CompanyAdmin", "COMPANYADMIN" },
                    { "40adcf81-05bd-4e93-9a90-a7830c57784f", null, "CompanyUser", "COMPANYUSER" },
                    { "7c9a3b12-2ac3-4187-87ab-cc11d96890e9", null, "User", "USER" },
                    { "a749b957-445d-4d22-91bf-f3c8644705d7", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "LogItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 29, 14, 37, 8, 815, DateTimeKind.Utc).AddTicks(6855));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 29, 14, 37, 8, 815, DateTimeKind.Utc).AddTicks(6739));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invites");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ad2fe29-fc9d-442c-a21b-3e6cee5360b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40adcf81-05bd-4e93-9a90-a7830c57784f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c9a3b12-2ac3-4187-87ab-cc11d96890e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a749b957-445d-4d22-91bf-f3c8644705d7");

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
    }
}
