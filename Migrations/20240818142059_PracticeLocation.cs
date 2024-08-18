using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shredule.Migrations
{
    /// <inheritdoc />
    public partial class PracticeLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Practices",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Practices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Location",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Practices");
        }
    }
}
