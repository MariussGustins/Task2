using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Task2.Migrations
{
    public partial class SeedResidents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Residents",
                columns: new[] { "Id", "ApartmentId", "Birthday", "Email", "LastName", "Name", "PersonalNumber", "PhoneNumber", "IsOwner" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1985, 4, 23), "john.doe@example.com", "Doe", "John", "12345-67890", 27497659, true },
                    { 2, 2, new DateTime(1985, 8, 20), "jane.smith@example.com", "Smith", "Jane", "09876-54321", 274547639, true },
                    { 3, 2, new DateTime(1982, 10, 12), "michael.johnson@example.com", "Johnson", "Michael", "24680-13579", 23494655, false },
                    { 4, 3, new DateTime(1995, 3, 25), "emily.williams@example.com", "Williams", "Emily", "13579-24680", 26497153, true }
                });
        }

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