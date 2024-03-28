using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class RelationshipTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserCompany_AspNetUsers_ApplicationUsersId",
                table: "ApplicationUserCompany");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserCompany_Companys_CompaniesId",
                table: "ApplicationUserCompany");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserCompany",
                table: "ApplicationUserCompany");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1728592a-ef4f-4266-8056-b1c49588a5a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41d048ba-8d9c-4873-9a70-cf21a20a19dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c35e2824-8c06-4d9e-8746-7f5f3f2b7701");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb25849a-4d1f-40be-b553-40e4dbd006ab");

            migrationBuilder.RenameTable(
                name: "ApplicationUserCompany",
                newName: "CompanyUser");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserCompany_CompaniesId",
                table: "CompanyUser",
                newName: "IX_CompanyUser_CompaniesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyUser",
                table: "CompanyUser",
                columns: new[] { "ApplicationUsersId", "CompaniesId" });

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyUser",
                table: "CompanyUser");

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

            migrationBuilder.RenameTable(
                name: "CompanyUser",
                newName: "ApplicationUserCompany");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyUser_CompaniesId",
                table: "ApplicationUserCompany",
                newName: "IX_ApplicationUserCompany_CompaniesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserCompany",
                table: "ApplicationUserCompany",
                columns: new[] { "ApplicationUsersId", "CompaniesId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1728592a-ef4f-4266-8056-b1c49588a5a5", null, "Administrator", "ADMINISTRATOR" },
                    { "41d048ba-8d9c-4873-9a70-cf21a20a19dc", null, "CompanyAdmin", "COMPANYADMIN" },
                    { "c35e2824-8c06-4d9e-8746-7f5f3f2b7701", null, "CompanyUser", "COMPANYUSER" },
                    { "cb25849a-4d1f-40be-b553-40e4dbd006ab", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "LogItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 28, 21, 49, 5, 233, DateTimeKind.Utc).AddTicks(1818));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 28, 21, 49, 5, 233, DateTimeKind.Utc).AddTicks(1676));

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserCompany_AspNetUsers_ApplicationUsersId",
                table: "ApplicationUserCompany",
                column: "ApplicationUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserCompany_Companys_CompaniesId",
                table: "ApplicationUserCompany",
                column: "CompaniesId",
                principalTable: "Companys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
