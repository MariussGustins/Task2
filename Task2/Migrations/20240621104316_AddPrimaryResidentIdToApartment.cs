using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task2.Migrations
{
    /// <inheritdoc />
    public partial class AddPrimaryResidentIdToApartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Ensure all PrimaryResidentId values are valid or set to NULL
            migrationBuilder.Sql("UPDATE Apartments SET PrimaryResidentId = NULL WHERE PrimaryResidentId NOT IN (SELECT Id FROM Residents)");

            migrationBuilder.AddColumn<int>(
                name: "PrimaryResidentId",
                table: "Apartments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_PrimaryResidentId",
                table: "Apartments",
                column: "PrimaryResidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Residents_PrimaryResidentId",
                table: "Apartments",
                column: "PrimaryResidentId",
                principalTable: "Residents",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Residents_PrimaryResidentId",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_PrimaryResidentId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "PrimaryResidentId",
                table: "Apartments");
        }
    }

}
