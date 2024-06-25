using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task2.Migrations
{
    /// <inheritdoc />
    public partial class SeedApartments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[]
                {
                    "Id", "Number", "Floor", "Rooms", "NumberOfResidents", "FullArea", "LivingArea", "HouseId",
                    "PrimaryResidentId"
                },
                values: new object[,]
                {
                    { 1, 5, 2, 1, 2, 40.5, 38.5, 1, 1 }, 
                    { 2, 3, 2, 2, 2, 70.5, 68.5, 1, null },
                    { 3, 1, 1, 3, 2, 93.5, 86.5, 2, 2 }, 
                    { 4, 2, 1, 2, 1, 80.5, 68.5, 2, null }, 
                    { 5, 6, 2, 1, 1, 50.0, 45.9, 2, 3 } 
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
