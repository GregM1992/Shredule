using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shredule.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Bands",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.istockphoto.com%2Fphotos%2Flive-crawfish&psig=AOvVaw2JjsOS4Pa4iECZ35pGTyiL&ust=1731620204747000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCPDz_Yui2okDFQAAAAAdAAAAABAE");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://www.google.com/url?sa=i&url=https%3A%2F%2Fthenounproject.com%2Fbrowse%2Ficons%2Fterm%2Fblank-profile%2F&psig=AOvVaw1htfEIJYHXkNrLoKRBHDLk&ust=1731620342893000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCKCB1c2i2okDFQAAAAAdAAAAABAE");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://www.google.com/url?sa=i&url=https%3A%2F%2Fthenounproject.com%2Fbrowse%2Ficons%2Fterm%2Fblank-profile%2F&psig=AOvVaw1htfEIJYHXkNrLoKRBHDLk&ust=1731620342893000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCKCB1c2i2okDFQAAAAAdAAAAABAE");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://www.google.com/url?sa=i&url=https%3A%2F%2Fthenounproject.com%2Fbrowse%2Ficons%2Fterm%2Fblank-profile%2F&psig=AOvVaw1htfEIJYHXkNrLoKRBHDLk&ust=1731620342893000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCKCB1c2i2okDFQAAAAAdAAAAABAE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Bands");
        }
    }
}
