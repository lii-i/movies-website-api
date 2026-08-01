using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movie_website_api.Migrations
{
    /// <inheritdoc />
    public partial class AddCensoredColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Censored",
                table: "Animes",
                type: "boolean",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Censored",
                table: "Animes");
        }
    }
}
