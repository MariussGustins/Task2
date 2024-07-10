using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task2.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToResidents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            // Assuming the initial UserId values for existing Residents are not known, set default to null or adjust as needed
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

            // Creating index for UserId in Residents table
            migrationBuilder.CreateIndex(
                name: "IX_Residents_UserId",
                table: "Residents",
                column: "UserId");

            // Adding foreign key constraint
            migrationBuilder.AddForeignKey(
                name: "FK_Residents_Users_UserId",
                table: "Residents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Residents_Users_UserId",
                table: "Residents");

            migrationBuilder.DropIndex(
                name: "IX_Residents_UserId",
                table: "Residents");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Residents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users"
            );
        }
    }
}
