using Microsoft.EntityFrameworkCore.Migrations;

namespace Task2.Migrations
{
    public partial class UpdateSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddColumn<bool>(
                name: "IsOwner",
                table: "Residents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PrimaryResidentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PrimaryResidentId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PrimaryResidentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 4,
                column: "PrimaryResidentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 5,
                column: "PrimaryResidentId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_PrimaryResidentId",
                table: "Apartments",
                column: "PrimaryResidentId");
            
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
            
            migrationBuilder.DropColumn(
                name: "IsOwner",
                table: "Residents");
        }
    }
}
