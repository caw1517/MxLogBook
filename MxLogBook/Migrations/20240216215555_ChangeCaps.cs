using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCaps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_log_items_AspNetUsers_UserId",
                table: "log_items");

            migrationBuilder.DropForeignKey(
                name: "FK_log_items_vehicles_VehicleId",
                table: "log_items");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_AspNetUsers_ApplicationUserId",
                table: "vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_vehicles",
                table: "vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_log_items",
                table: "log_items");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01a44da2-4852-4c2a-b0aa-29897e75dd57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0add4abb-9e3c-4ca2-95d2-3ebeb164cc50");

            migrationBuilder.RenameTable(
                name: "vehicles",
                newName: "Vehicles");

            migrationBuilder.RenameTable(
                name: "log_items",
                newName: "LogItems");

            migrationBuilder.RenameIndex(
                name: "IX_vehicles_ApplicationUserId",
                table: "Vehicles",
                newName: "IX_Vehicles_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_log_items_VehicleId",
                table: "LogItems",
                newName: "IX_LogItems_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_log_items_UserId",
                table: "LogItems",
                newName: "IX_LogItems_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LogItems",
                table: "LogItems",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SignOffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkPerformed = table.Column<string>(type: "text", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CompletesItem = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    UserId1 = table.Column<string>(type: "text", nullable: true),
                    LogId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignOffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignOffs_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SignOffs_LogItems_LogId",
                        column: x => x.LogId,
                        principalTable: "LogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_SignOffs_LogId",
                table: "SignOffs",
                column: "LogId");

            migrationBuilder.CreateIndex(
                name: "IX_SignOffs_UserId1",
                table: "SignOffs",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_LogItems_AspNetUsers_UserId",
                table: "LogItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LogItems_Vehicles_VehicleId",
                table: "LogItems",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_AspNetUsers_ApplicationUserId",
                table: "Vehicles",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogItems_AspNetUsers_UserId",
                table: "LogItems");

            migrationBuilder.DropForeignKey(
                name: "FK_LogItems_Vehicles_VehicleId",
                table: "LogItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_AspNetUsers_ApplicationUserId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "SignOffs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LogItems",
                table: "LogItems");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f61fcb34-5394-48bd-8caa-a25cc6d6d71a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcad6f7b-9245-40b7-86eb-25e55332612a");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "vehicles");

            migrationBuilder.RenameTable(
                name: "LogItems",
                newName: "log_items");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_ApplicationUserId",
                table: "vehicles",
                newName: "IX_vehicles_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_LogItems_VehicleId",
                table: "log_items",
                newName: "IX_log_items_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_LogItems_UserId",
                table: "log_items",
                newName: "IX_log_items_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_vehicles",
                table: "vehicles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_log_items",
                table: "log_items",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01a44da2-4852-4c2a-b0aa-29897e75dd57", null, "User", "USER" },
                    { "0add4abb-9e3c-4ca2-95d2-3ebeb164cc50", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "log_items",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 16, 21, 29, 10, 360, DateTimeKind.Utc).AddTicks(5604));

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 16, 21, 29, 10, 360, DateTimeKind.Utc).AddTicks(5504));

            migrationBuilder.AddForeignKey(
                name: "FK_log_items_AspNetUsers_UserId",
                table: "log_items",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_log_items_vehicles_VehicleId",
                table: "log_items",
                column: "VehicleId",
                principalTable: "vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_AspNetUsers_ApplicationUserId",
                table: "vehicles",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
