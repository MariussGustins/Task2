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
                columns: new[] { "Id", "Floor", "FullArea", "HouseId", "LivingArea", "Number", "NumberOfResidents", "Rooms" },
                values: new object[,]
                {
                    { 1, 2, 40.5, 1, 38.5, 5, 2, 1 },
                    { 2, 2, 70.5, 1, 68.5, 3, 2, 2 },
                    { 3, 1, 93.5, 2, 86.5, 1, 2, 3 },
                    { 4, 1, 80.5, 2, 68.5, 2, 1, 2 },
                    { 5, 2, 50.0, 2, 45.899999999999999, 6, 1, 1 }
                });
        }

        /// <inheritdoc />
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
