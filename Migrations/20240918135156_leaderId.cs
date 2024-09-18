using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shredule.Migrations
{
    /// <inheritdoc />
    public partial class leaderId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LeaderId",
                table: "Bands",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 1,
                column: "LeaderId",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeaderId",
                table: "Bands");
        }
    }
}
