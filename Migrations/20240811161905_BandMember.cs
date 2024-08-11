using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shredule.Migrations
{
    /// <inheritdoc />
    public partial class BandMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bands_Users_UserId",
                table: "Bands");

            migrationBuilder.DropIndex(
                name: "IX_Bands_UserId",
                table: "Bands");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bands");

            migrationBuilder.CreateTable(
                name: "BandUser",
                columns: table => new
                {
                    BandsId = table.Column<int>(type: "integer", nullable: false),
                    MembersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandUser", x => new { x.BandsId, x.MembersId });
                    table.ForeignKey(
                        name: "FK_BandUser_Bands_BandsId",
                        column: x => x.BandsId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BandUser_Users_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BandUser_MembersId",
                table: "BandUser",
                column: "MembersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BandUser");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Bands",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Bands_UserId",
                table: "Bands",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bands_Users_UserId",
                table: "Bands",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
