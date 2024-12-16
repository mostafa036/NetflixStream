using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetflixStream.Persistence.Data.Migrations.NetflixStreamMigrations
{
    /// <inheritdoc />
    public partial class v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PosterName",
                table: "Movies",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PosterName",
                table: "Movies");
        }
    }
}
