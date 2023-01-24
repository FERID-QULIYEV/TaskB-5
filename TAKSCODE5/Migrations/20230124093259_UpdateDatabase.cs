using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TAKSCODE5.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeId",
                table: "Pozitions");

            migrationBuilder.AddColumn<int>(
                name: "PozitionId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PozitionId",
                table: "Employees",
                column: "PozitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Pozitions_PozitionId",
                table: "Employees",
                column: "PozitionId",
                principalTable: "Pozitions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Pozitions_PozitionId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PozitionId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PozitionId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "EmployeId",
                table: "Pozitions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
