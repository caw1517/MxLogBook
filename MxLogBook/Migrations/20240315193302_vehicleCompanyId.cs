using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class vehicleCompanyId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Vehicles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CompanyId",
                table: "Vehicles",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Companys_CompanyId",
                table: "Vehicles",
                column: "CompanyId",
                principalTable: "Companys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Companys_CompanyId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_CompanyId",
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

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Vehicles");

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
    }
}
