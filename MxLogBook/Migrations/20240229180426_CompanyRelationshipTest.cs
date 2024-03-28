using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class CompanyRelationshipTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
