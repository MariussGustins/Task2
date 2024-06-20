using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task2.Migrations
{
    /// <inheritdoc />
    public partial class AddIsOwnerToResident : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOwner",
                table: "Residents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PrimaryResidentId",
                table: "Apartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PrimaryResidentId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PrimaryResidentId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PrimaryResidentId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 4,
                column: "PrimaryResidentId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 5,
                column: "PrimaryResidentId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsOwner",
                value: true);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsOwner",
                value: true);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsOwner",
                value: false);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsOwner",
                value: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_PrimaryResidentId",
                table: "Apartments",
                column: "PrimaryResidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Residents_PrimaryResidentId",
                table: "Apartments",
                column: "PrimaryResidentId",
                principalTable: "Residents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Residents_PrimaryResidentId",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_PrimaryResidentId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "IsOwner",
                table: "Residents");

            migrationBuilder.DropColumn(
                name: "PrimaryResidentId",
                table: "Apartments");
        }
    }
}
