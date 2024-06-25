using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task2.Migrations
{
    public partial class AddPrimaryResidentIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Check if the column exists before adding it
            if (!ColumnExists(migrationBuilder, "Apartments", "PrimaryResidentId"))
            {
                migrationBuilder.AddColumn<int>(
                    name: "PrimaryResidentId",
                    table: "Apartments",
                    nullable: true);
            }

            migrationBuilder.Sql(@"
            UPDATE Apartments
            SET PrimaryResidentId = NULL
            WHERE PrimaryResidentId IS NOT NULL AND PrimaryResidentId NOT IN (SELECT Id FROM Residents);
        ");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Residents_PrimaryResidentId",
                table: "Apartments");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Residents_PrimaryResidentId",
                table: "Apartments",
                column: "PrimaryResidentId",
                principalTable: "Residents",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Residents_PrimaryResidentId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "PrimaryResidentId",
                table: "Apartments");
        }

        private bool ColumnExists(MigrationBuilder migrationBuilder, string tableName, string columnName)
        {
            var table = migrationBuilder.Sql($"SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}' AND COLUMN_NAME = '{columnName}'");
            return table != null;
        }
    }

}
