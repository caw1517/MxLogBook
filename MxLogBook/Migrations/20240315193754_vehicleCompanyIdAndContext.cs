using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class vehicleCompanyIdAndContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Companys_CompanyId",
                table: "Vehicles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4322a0fc-a16e-4ce7-a876-7aa019257a8b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2145f3e-8462-41aa-9649-c92264c186ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfdd35e6-0c00-4031-b3d1-b270c7f6b227");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa839868-2632-4447-8212-5599c9f0b630");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Vehicles",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cc0324b6-5e55-4b66-ad34-3c43644f77d0", null, "User", "USER" },
                    { "e2573724-09f8-498f-8973-6562cf593b5a", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "LogItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 15, 19, 37, 53, 466, DateTimeKind.Utc).AddTicks(9713));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompanyId", "CreatedOn" },
                values: new object[] { 1, new DateTime(2024, 3, 15, 19, 37, 53, 466, DateTimeKind.Utc).AddTicks(9570) });

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Companys_CompanyId",
                table: "Vehicles",
                column: "CompanyId",
                principalTable: "Companys",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Companys_CompanyId",
                table: "Vehicles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc0324b6-5e55-4b66-ad34-3c43644f77d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2573724-09f8-498f-8973-6562cf593b5a");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Vehicles",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4322a0fc-a16e-4ce7-a876-7aa019257a8b", null, "CompanyUser", "COMPANYUSER" },
                    { "a2145f3e-8462-41aa-9649-c92264c186ed", null, "Administrator", "ADMINISTRATOR" },
                    { "dfdd35e6-0c00-4031-b3d1-b270c7f6b227", null, "CompanyAdmin", "COMPANYADMIN" },
                    { "fa839868-2632-4447-8212-5599c9f0b630", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "LogItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 15, 19, 33, 1, 912, DateTimeKind.Utc).AddTicks(2169));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompanyId", "CreatedOn" },
                values: new object[] { 0, new DateTime(2024, 3, 15, 19, 33, 1, 912, DateTimeKind.Utc).AddTicks(2019) });

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Companys_CompanyId",
                table: "Vehicles",
                column: "CompanyId",
                principalTable: "Companys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
