using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basketball.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSeedData_StarksTeamId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                column: "TeamId",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                column: "TeamId",
                value: 1);
        }
    }
}
