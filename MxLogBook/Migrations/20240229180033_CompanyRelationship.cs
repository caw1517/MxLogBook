using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class CompanyRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyUser_AspNetUsers_ApplicationUsersId",
                table: "CompanyUser");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyUser_Companys_CompaniesId",
                table: "CompanyUser");

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

            migrationBuilder.RenameColumn(
                name: "CompaniesId",
                table: "CompanyUser",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUsersId",
                table: "CompanyUser",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyUser_CompaniesId",
                table: "CompanyUser",
                newName: "IX_CompanyUser_CompanyId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "159a5992-4000-425a-9dc0-8e54620d9dd7", null, "Administrator", "ADMINISTRATOR" },
                    { "3cd12bd6-6611-4983-bc22-54715c8f099b", null, "CompanyAdmin", "COMPANYADMIN" },
                    { "46ff373a-02b6-4019-8c10-01fca6360e30", null, "CompanyUser", "COMPANYUSER" },
                    { "fb0eb9ee-2503-4252-9781-40b81a5d5b0c", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "LogItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 29, 18, 0, 33, 453, DateTimeKind.Utc).AddTicks(463));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 29, 18, 0, 33, 453, DateTimeKind.Utc).AddTicks(349));

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyUser_AspNetUsers_UserId",
                table: "CompanyUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyUser_Companys_CompanyId",
                table: "CompanyUser",
                column: "CompanyId",
                principalTable: "Companys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyUser_AspNetUsers_UserId",
                table: "CompanyUser");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyUser_Companys_CompanyId",
                table: "CompanyUser");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "159a5992-4000-425a-9dc0-8e54620d9dd7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cd12bd6-6611-4983-bc22-54715c8f099b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46ff373a-02b6-4019-8c10-01fca6360e30");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb0eb9ee-2503-4252-9781-40b81a5d5b0c");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "CompanyUser",
                newName: "CompaniesId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CompanyUser",
                newName: "ApplicationUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyUser_CompanyId",
                table: "CompanyUser",
                newName: "IX_CompanyUser_CompaniesId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyUser_AspNetUsers_ApplicationUsersId",
                table: "CompanyUser",
                column: "ApplicationUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyUser_Companys_CompaniesId",
                table: "CompanyUser",
                column: "CompaniesId",
                principalTable: "Companys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
