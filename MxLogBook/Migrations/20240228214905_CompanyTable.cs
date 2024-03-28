using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class CompanyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5735e1a9-0d7e-4420-984c-c5f4e167a405");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dca342d5-c876-48b5-994b-e6cc16b9fa69");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1a8f6f9-2c56-49af-9eab-5f7ed99447ab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f763167c-f7c3-4197-bb4b-227f6971e7f3");

            migrationBuilder.CreateTable(
                name: "Companys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserCompany",
                columns: table => new
                {
                    ApplicationUsersId = table.Column<string>(type: "text", nullable: false),
                    CompaniesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserCompany", x => new { x.ApplicationUsersId, x.CompaniesId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserCompany_AspNetUsers_ApplicationUsersId",
                        column: x => x.ApplicationUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserCompany_Companys_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserCompany_CompaniesId",
                table: "ApplicationUserCompany",
                column: "CompaniesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserCompany");

            migrationBuilder.DropTable(
                name: "Companys");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5735e1a9-0d7e-4420-984c-c5f4e167a405", null, "CompanyUser", "COMPANYUSER" },
                    { "dca342d5-c876-48b5-994b-e6cc16b9fa69", null, "User", "USER" },
                    { "e1a8f6f9-2c56-49af-9eab-5f7ed99447ab", null, "Administrator", "ADMINISTRATOR" },
                    { "f763167c-f7c3-4197-bb4b-227f6971e7f3", null, "CompanyAdmin", "COMPANYADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "LogItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 28, 21, 23, 20, 668, DateTimeKind.Utc).AddTicks(9476));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 28, 21, 23, 20, 668, DateTimeKind.Utc).AddTicks(9393));
        }
    }
}
