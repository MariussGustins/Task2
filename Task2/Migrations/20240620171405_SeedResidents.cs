using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task2.Migrations
{
    /// <inheritdoc />
    public partial class SeedResidents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Residents",
                columns: new[] { "Id", "ApartmentId", "Birthday", "Email", "LastName", "Name", "PersonalNumber", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, new DateOnly(1985, 4, 23), "john.doe@example.com", "Doe", "John", "12345-67890", 27497659 },
                    { 2, 2, new DateOnly(1985, 8, 20), "jane.smith@example.com", "Smith", "Jane", "09876-54321", 274547639 },
                    { 3, 2, new DateOnly(1982, 10, 12), "michael.johnson@example.com", "Johnson", "Michael", "24680-13579", 23494655 },
                    { 4, 3, new DateOnly(1995, 3, 25), "emily.williams@example.com", "Williams", "Emily", "13579-24680", 26497153 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
