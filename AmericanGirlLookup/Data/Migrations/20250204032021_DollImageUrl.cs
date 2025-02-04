using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmericanGirlLookup.Data.Migrations
{
    /// <inheritdoc />
    public partial class DollImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Doll");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Doll",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Doll");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Doll",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
