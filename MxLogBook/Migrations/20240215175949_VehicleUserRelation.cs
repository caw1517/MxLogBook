using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class VehicleUserRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21823a9a-41d8-4232-8557-76767e8ed362");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe0a1efc-4fcf-411b-98a5-95943b3066d8");

            migrationBuilder.DeleteData(
                table: "vehicles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "vehicles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "vehicles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad688228-bb74-4275-9c68-e1ef4bab05b1", null, "User", "USER" },
                    { "c985a73a-fa6b-4af1-8e73-3848970f9b5e", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "log_items",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 15, 17, 59, 48, 486, DateTimeKind.Utc).AddTicks(7994));

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApplicationUserId", "CreatedOn", "UserId" },
                values: new object[] { null, new DateTime(2024, 2, 15, 17, 59, 48, 486, DateTimeKind.Utc).AddTicks(7873), "66b55995-d23f-4b07-ab16-6425b63c603d" });

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_ApplicationUserId",
                table: "vehicles",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_AspNetUsers_ApplicationUserId",
                table: "vehicles",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_AspNetUsers_ApplicationUserId",
                table: "vehicles");

            migrationBuilder.DropIndex(
                name: "IX_vehicles_ApplicationUserId",
                table: "vehicles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad688228-bb74-4275-9c68-e1ef4bab05b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c985a73a-fa6b-4af1-8e73-3848970f9b5e");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "vehicles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "21823a9a-41d8-4232-8557-76767e8ed362", null, "User", "USER" },
                    { "fe0a1efc-4fcf-411b-98a5-95943b3066d8", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "log_items",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 5, 15, 48, 10, 798, DateTimeKind.Utc).AddTicks(3485));

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 5, 15, 48, 10, 798, DateTimeKind.Utc).AddTicks(3267));

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "Id", "CreatedOn", "Hours", "Make", "Mileage", "Model", "Year" },
                values: new object[] { 2, new DateTime(2024, 2, 5, 15, 48, 10, 798, DateTimeKind.Utc).AddTicks(3269), 20, "Honda", null, "CRF250R", 2023 });
        }
    }
}
