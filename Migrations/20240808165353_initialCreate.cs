using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shredule.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Availability",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    MonMorn = table.Column<bool>(type: "boolean", nullable: false),
                    TueMorn = table.Column<bool>(type: "boolean", nullable: false),
                    WedMorn = table.Column<bool>(type: "boolean", nullable: false),
                    ThurMorn = table.Column<bool>(type: "boolean", nullable: false),
                    FriMorn = table.Column<bool>(type: "boolean", nullable: false),
                    SatMorn = table.Column<bool>(type: "boolean", nullable: false),
                    SunMorn = table.Column<bool>(type: "boolean", nullable: false),
                    MonNight = table.Column<bool>(type: "boolean", nullable: false),
                    TueNight = table.Column<bool>(type: "boolean", nullable: false),
                    WedNight = table.Column<bool>(type: "boolean", nullable: false),
                    ThurNight = table.Column<bool>(type: "boolean", nullable: false),
                    FriNight = table.Column<bool>(type: "boolean", nullable: false),
                    SatNight = table.Column<bool>(type: "boolean", nullable: false),
                    SunNight = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availability", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Venue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    AvailabilityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    ScheduleId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bands_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BandShow",
                columns: table => new
                {
                    BandsId = table.Column<int>(type: "integer", nullable: false),
                    ShowsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandShow", x => new { x.BandsId, x.ShowsId });
                    table.ForeignKey(
                        name: "FK_BandShow_Bands_BandsId",
                        column: x => x.BandsId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BandShow_Shows_ShowsId",
                        column: x => x.ShowsId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Practices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BandId = table.Column<int>(type: "integer", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Practices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Practices_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Availability",
                columns: new[] { "Id", "FriMorn", "FriNight", "MonMorn", "MonNight", "SatMorn", "SatNight", "SunMorn", "SunNight", "ThurMorn", "ThurNight", "TueMorn", "TueNight", "UserId", "WedMorn", "WedNight" },
                values: new object[,]
                {
                    { 1, false, false, true, true, true, true, false, false, false, true, true, false, 1, false, true },
                    { 2, false, false, false, true, true, true, false, true, false, false, true, false, 2, true, true }
                });

            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "Id", "Name", "Password", "ScheduleId", "UserId" },
                values: new object[] { 1, "Cull", "nunusCrawfish", 1, null });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "DateTime", "Venue" },
                values: new object[] { 2, new DateTime(24, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "BlackBird Tattoo" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvailabilityId", "Name", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, 1, "Greg Markus", "PrimusSucks", "BassBoi92" },
                    { 2, 2, "Elias Macdonald", "ThickieBig", "BigThickie" },
                    { 3, 3, "Justin Welch", "DerfoBlood", "JasonWalkerBRI" }
                });

            migrationBuilder.InsertData(
                table: "Practices",
                columns: new[] { "Id", "BandId", "DateTime" },
                values: new object[] { 1, 1, new DateTime(24, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Bands_UserId",
                table: "Bands",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BandShow_ShowsId",
                table: "BandShow",
                column: "ShowsId");

            migrationBuilder.CreateIndex(
                name: "IX_Practices_BandId",
                table: "Practices",
                column: "BandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Availability");

            migrationBuilder.DropTable(
                name: "BandShow");

            migrationBuilder.DropTable(
                name: "Practices");

            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "Bands");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
