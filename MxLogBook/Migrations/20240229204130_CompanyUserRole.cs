using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class CompanyUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyUser");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55ada520-676a-451e-a05c-ea6fbb2900e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6003d622-2f59-488f-af20-131ee6380a05");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65f12336-1252-4a50-9a68-b3ddb1e900de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9a68ac9-f3a2-4ef6-a7f5-a76fa69e7b84");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CompanyId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyUserRoles", x => new { x.UserId, x.CompanyId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_CompanyUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyUserRoles_Companys_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyUserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06ea4434-9299-4b58-b754-7680d4da8247", null, "CompanyAdmin", "COMPANYADMIN" },
                    { "55a99274-98b3-42e6-a879-4e4abf0ee5a6", null, "User", "USER" },
                    { "831bc48c-951e-4ded-9223-b1223ef257c4", null, "CompanyUser", "COMPANYUSER" },
                    { "c71607f0-c8b6-4b19-8672-8f2210a0e54e", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "LogItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 29, 20, 41, 29, 595, DateTimeKind.Utc).AddTicks(2446));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 29, 20, 41, 29, 595, DateTimeKind.Utc).AddTicks(2298));

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUserRoles_CompanyId",
                table: "CompanyUserRoles",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUserRoles_RoleId",
                table: "CompanyUserRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyUserRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06ea4434-9299-4b58-b754-7680d4da8247");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55a99274-98b3-42e6-a879-4e4abf0ee5a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "831bc48c-951e-4ded-9223-b1223ef257c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c71607f0-c8b6-4b19-8672-8f2210a0e54e");

            migrationBuilder.CreateTable(
                name: "CompanyUser",
                columns: table => new
                {
                    ApplicationUsersId = table.Column<string>(type: "text", nullable: false),
                    CompaniesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyUser", x => new { x.ApplicationUsersId, x.CompaniesId });
                    table.ForeignKey(
                        name: "FK_CompanyUser_AspNetUsers_ApplicationUsersId",
                        column: x => x.ApplicationUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyUser_Companys_CompaniesId",
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
                    { "55ada520-676a-451e-a05c-ea6fbb2900e4", null, "CompanyAdmin", "COMPANYADMIN" },
                    { "6003d622-2f59-488f-af20-131ee6380a05", null, "CompanyUser", "COMPANYUSER" },
                    { "65f12336-1252-4a50-9a68-b3ddb1e900de", null, "User", "USER" },
                    { "b9a68ac9-f3a2-4ef6-a7f5-a76fa69e7b84", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "LogItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 29, 19, 2, 27, 888, DateTimeKind.Utc).AddTicks(9994));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 29, 19, 2, 27, 888, DateTimeKind.Utc).AddTicks(9905));

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUser_CompaniesId",
                table: "CompanyUser",
                column: "CompaniesId");
        }
    }
}
