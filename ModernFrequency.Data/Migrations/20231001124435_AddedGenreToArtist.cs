using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModernFrequency.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedGenreToArtist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Genre",
                table: "Artists",
                type: "int",
                maxLength: 11,
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Artists");
        }
    }
}
