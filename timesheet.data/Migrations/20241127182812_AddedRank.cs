using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace timesheet.data.Migrations
{
    /// <inheritdoc />
    public partial class AddedRank : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeRankId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RankId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EmployeeRank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rank = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRank", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeRankId",
                table: "Employees",
                column: "EmployeeRankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeRank_EmployeeRankId",
                table: "Employees",
                column: "EmployeeRankId",
                principalTable: "EmployeeRank",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeRank_EmployeeRankId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "EmployeeRank");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeRankId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeRankId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "RankId",
                table: "Employees");
        }
    }
}
