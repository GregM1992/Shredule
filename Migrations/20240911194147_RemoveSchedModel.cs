using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Shredule.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSchedModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Practices_Schedules_ScheduleId",
                table: "Practices");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Schedules_ScheduleId",
                table: "Shows");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Shows_ScheduleId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Practices_ScheduleId",
                table: "Practices");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Practices");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "Shows",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "Practices",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BandId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Practices",
                keyColumn: "Id",
                keyValue: 1,
                column: "ScheduleId",
                value: null);

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "BandId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 2,
                column: "ScheduleId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Shows_ScheduleId",
                table: "Shows",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Practices_ScheduleId",
                table: "Practices",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Practices_Schedules_ScheduleId",
                table: "Practices",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Schedules_ScheduleId",
                table: "Shows",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id");
        }
    }
}
