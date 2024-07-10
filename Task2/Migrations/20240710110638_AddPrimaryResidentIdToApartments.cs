using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task2.Migrations
{
    /// <inheritdoc />
    public partial class AddPrimaryResidentIdToApartments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Residents_PrimaryResidentId",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Residents_Apartments_ApartmentId",
                table: "Residents");

            migrationBuilder.DropForeignKey(
                name: "FK_Residents_Users_UserId",
                table: "Residents");

            migrationBuilder.DropIndex(
                name: "IX_Residents_UserId",
                table: "Residents");

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

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Residents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Residents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "UserId", "Username" },
                values: new object[] { "DefaultPassword123", 2, "JohnDoe" });

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "UserId", "Username" },
                values: new object[] { "DefaultPassword123", 3, "JaneSmith" });

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "UserId", "Username" },
                values: new object[] { "DefaultPassword123", 4, "MichealJohnson" });

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "UserId", "Username" },
                values: new object[] { "DefaultPassword123", 5, "EmilyWilliams" });

            migrationBuilder.CreateIndex(
                name: "IX_Residents_UserId",
                table: "Residents",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Residents_PrimaryResidentId",
                table: "Apartments",
                column: "PrimaryResidentId",
                principalTable: "Residents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Residents_Apartments_ApartmentId",
                table: "Residents",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Residents_Users_UserId",
                table: "Residents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Residents_PrimaryResidentId",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Residents_Apartments_ApartmentId",
                table: "Residents");

            migrationBuilder.DropForeignKey(
                name: "FK_Residents_Users_UserId",
                table: "Residents");

            migrationBuilder.DropIndex(
                name: "IX_Residents_UserId",
                table: "Residents");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Residents");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Residents");

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "City", "Country", "Number", "Postcode", "Street" },
                values: new object[,]
                {
                    { 1, "Springfield", "USA", "123", "12345", "Elm Street" },
                    { 2, "Springfield", "USA", "456", "67890", "Maple Avenue" }
                });

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: null);

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "Floor", "FullArea", "HouseId", "LivingArea", "Number", "NumberOfResidents", "PrimaryResidentId", "Rooms" },
                values: new object[,]
                {
                    { 1, 2, 40.5, 1, 38.5, 5, 2, 1, 1 },
                    { 2, 2, 70.5, 1, 68.5, 3, 2, 2, 2 },
                    { 3, 1, 93.5, 2, 86.5, 1, 2, null, 3 },
                    { 4, 1, 80.5, 2, 68.5, 2, 1, null, 2 },
                    { 5, 2, 50.0, 2, 45.899999999999999, 6, 1, 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Residents_UserId",
                table: "Residents",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Residents_PrimaryResidentId",
                table: "Apartments",
                column: "PrimaryResidentId",
                principalTable: "Residents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Residents_Apartments_ApartmentId",
                table: "Residents",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Residents_Users_UserId",
                table: "Residents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
