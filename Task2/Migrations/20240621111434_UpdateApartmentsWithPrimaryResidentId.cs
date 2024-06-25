using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task2.Migrations
{
    /// <inheritdoc />
    public partial class UpdateApartmentsWithPrimaryResidentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Residents_PrimaryResidentId",
                table: "Apartments");

            migrationBuilder.AlterColumn<string>(
                name: "PersonalNumber",
                table: "Residents",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "PrimaryResidentId",
                table: "Apartments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ResidentId",
                table: "Apartments",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PrimaryResidentId", "ResidentId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PrimaryResidentId", "ResidentId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PrimaryResidentId", "ResidentId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PrimaryResidentId", "ResidentId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PrimaryResidentId", "ResidentId" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Residents_PersonalNumber",
                table: "Residents",
                column: "PersonalNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_ResidentId",
                table: "Apartments",
                column: "ResidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Residents_PrimaryResidentId",
                table: "Apartments",
                column: "PrimaryResidentId",
                principalTable: "Residents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Residents_ResidentId",
                table: "Apartments",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Residents_PrimaryResidentId",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Residents_ResidentId",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Residents_PersonalNumber",
                table: "Residents");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_ResidentId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "ResidentId",
                table: "Apartments");

            migrationBuilder.AlterColumn<string>(
                name: "PersonalNumber",
                table: "Residents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "PrimaryResidentId",
                table: "Apartments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Residents_PrimaryResidentId",
                table: "Apartments",
                column: "PrimaryResidentId",
                principalTable: "Residents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
