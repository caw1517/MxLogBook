using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbSetRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyUserRoles_Roles_RoleId",
                table: "CompanyUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0503f759-0b07-40f7-bfec-e2231c6057f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "382eee70-bc51-4ff7-beae-b6483101a44b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49e5fc5f-3925-407b-af8c-cd030ce439e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "787e99be-374c-4404-aa78-d8394b69fa76");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "CompanyRoles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyRoles",
                table: "CompanyRoles",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyUserRoles_CompanyRoles_RoleId",
                table: "CompanyUserRoles",
                column: "RoleId",
                principalTable: "CompanyRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyUserRoles_CompanyRoles_RoleId",
                table: "CompanyUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyRoles",
                table: "CompanyRoles");

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

            migrationBuilder.RenameTable(
                name: "CompanyRoles",
                newName: "Roles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0503f759-0b07-40f7-bfec-e2231c6057f5", null, "User", "USER" },
                    { "382eee70-bc51-4ff7-beae-b6483101a44b", null, "Administrator", "ADMINISTRATOR" },
                    { "49e5fc5f-3925-407b-af8c-cd030ce439e2", null, "CompanyAdmin", "COMPANYADMIN" },
                    { "787e99be-374c-4404-aa78-d8394b69fa76", null, "CompanyUser", "COMPANYUSER" }
                });

            migrationBuilder.UpdateData(
                table: "LogItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 29, 20, 54, 51, 915, DateTimeKind.Utc).AddTicks(2338));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 29, 20, 54, 51, 915, DateTimeKind.Utc).AddTicks(2240));

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyUserRoles_Roles_RoleId",
                table: "CompanyUserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
