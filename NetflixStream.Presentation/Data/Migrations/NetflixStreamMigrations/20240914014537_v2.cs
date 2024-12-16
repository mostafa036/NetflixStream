using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NetflixStream.Persistence.Data.Migrations.NetflixStreamMigrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EpisodeComments_Episodes_EpisodeID",
                table: "EpisodeComments");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieDirectors_Directors_DirectorsID",
                table: "MovieDirectors");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieDirectors_Movies_MoviesID",
                table: "MovieDirectors");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesCountries_Countries_CountriesID",
                table: "SeriesCountries");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesDirectors_Directors_DirectorsID",
                table: "SeriesDirectors");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesLanguages_Languages_LanguagesID",
                table: "SeriesLanguages");

            migrationBuilder.DropTable(
                name: "MovieCountries");

            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropTable(
                name: "MovieLanguages");

            migrationBuilder.DropTable(
                name: "MovieProducers");

            migrationBuilder.DropTable(
                name: "SeriesProduceres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeriesDirectors",
                table: "SeriesDirectors");

            migrationBuilder.DropIndex(
                name: "IX_SeriesDirectors_SeriesID",
                table: "SeriesDirectors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeriesCountries",
                table: "SeriesCountries");

            migrationBuilder.DropIndex(
                name: "IX_SeriesCountries_SeriesID",
                table: "SeriesCountries");

            migrationBuilder.DropIndex(
                name: "IX_EpisodeComments_EpisodeID",
                table: "EpisodeComments");

            migrationBuilder.RenameColumn(
                name: "LanguagesID",
                table: "SeriesLanguages",
                newName: "languageID");

            migrationBuilder.RenameColumn(
                name: "DirectorsID",
                table: "SeriesDirectors",
                newName: "DirectorID");

            migrationBuilder.RenameColumn(
                name: "CountriesID",
                table: "SeriesCountries",
                newName: "CountryID");

            migrationBuilder.RenameColumn(
                name: "MoviesID",
                table: "MovieDirectors",
                newName: "DirectorId");

            migrationBuilder.RenameColumn(
                name: "DirectorsID",
                table: "MovieDirectors",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieDirectors_MoviesID",
                table: "MovieDirectors",
                newName: "IX_MovieDirectors_DirectorId");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "EpisodeComments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeriesDirectors",
                table: "SeriesDirectors",
                columns: new[] { "SeriesID", "DirectorID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeriesCountries",
                table: "SeriesCountries",
                columns: new[] { "SeriesID", "CountryID" });

            migrationBuilder.CreateTable(
                name: "MoviesCountries",
                columns: table => new
                {
                    CountryID = table.Column<int>(type: "integer", nullable: false),
                    MoviesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesCountries", x => new { x.CountryID, x.MoviesID });
                    table.ForeignKey(
                        name: "FK_MoviesCountries_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesCountries_Movies_MoviesID",
                        column: x => x.MoviesID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviesGenres",
                columns: table => new
                {
                    GenresID = table.Column<int>(type: "integer", nullable: false),
                    MoviesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesGenres", x => new { x.GenresID, x.MoviesID });
                    table.ForeignKey(
                        name: "FK_MoviesGenres_Genres_GenresID",
                        column: x => x.GenresID,
                        principalTable: "Genres",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesGenres_Movies_MoviesID",
                        column: x => x.MoviesID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviesLanguages",
                columns: table => new
                {
                    LanguageID = table.Column<int>(type: "integer", nullable: false),
                    MoviesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesLanguages", x => new { x.MoviesID, x.LanguageID });
                    table.ForeignKey(
                        name: "FK_MoviesLanguages_Languages_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "Languages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesLanguages_Movies_MoviesID",
                        column: x => x.MoviesID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviesProducers",
                columns: table => new
                {
                    ProducerID = table.Column<int>(type: "integer", nullable: false),
                    MoviesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesProducers", x => new { x.ProducerID, x.MoviesID });
                    table.ForeignKey(
                        name: "FK_MoviesProducers_Movies_MoviesID",
                        column: x => x.MoviesID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesProducers_Producers_ProducerID",
                        column: x => x.ProducerID,
                        principalTable: "Producers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeriesProducers",
                columns: table => new
                {
                    ProducerID = table.Column<int>(type: "integer", nullable: false),
                    SeriesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesProducers", x => new { x.ProducerID, x.SeriesID });
                    table.ForeignKey(
                        name: "FK_SeriesProducers_Producers_ProducerID",
                        column: x => x.ProducerID,
                        principalTable: "Producers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeriesProducers_Series_SeriesID",
                        column: x => x.SeriesID,
                        principalTable: "Series",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeriesDirectors_DirectorID",
                table: "SeriesDirectors",
                column: "DirectorID");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesCountries_CountryID",
                table: "SeriesCountries",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesCountries_MoviesID",
                table: "MoviesCountries",
                column: "MoviesID");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesGenres_MoviesID",
                table: "MoviesGenres",
                column: "MoviesID");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesLanguages_LanguageID",
                table: "MoviesLanguages",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesProducers_MoviesID",
                table: "MoviesProducers",
                column: "MoviesID");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesProducers_SeriesID",
                table: "SeriesProducers",
                column: "SeriesID");

            migrationBuilder.AddForeignKey(
                name: "FK_EpisodeComments_Episodes_ID",
                table: "EpisodeComments",
                column: "ID",
                principalTable: "Episodes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDirectors_Directors_DirectorId",
                table: "MovieDirectors",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDirectors_Movies_MovieId",
                table: "MovieDirectors",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesCountries_Countries_CountryID",
                table: "SeriesCountries",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesDirectors_Directors_DirectorID",
                table: "SeriesDirectors",
                column: "DirectorID",
                principalTable: "Directors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesLanguages_Languages_languageID",
                table: "SeriesLanguages",
                column: "languageID",
                principalTable: "Languages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EpisodeComments_Episodes_ID",
                table: "EpisodeComments");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieDirectors_Directors_DirectorId",
                table: "MovieDirectors");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieDirectors_Movies_MovieId",
                table: "MovieDirectors");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesCountries_Countries_CountryID",
                table: "SeriesCountries");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesDirectors_Directors_DirectorID",
                table: "SeriesDirectors");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesLanguages_Languages_languageID",
                table: "SeriesLanguages");

            migrationBuilder.DropTable(
                name: "MoviesCountries");

            migrationBuilder.DropTable(
                name: "MoviesGenres");

            migrationBuilder.DropTable(
                name: "MoviesLanguages");

            migrationBuilder.DropTable(
                name: "MoviesProducers");

            migrationBuilder.DropTable(
                name: "SeriesProducers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeriesDirectors",
                table: "SeriesDirectors");

            migrationBuilder.DropIndex(
                name: "IX_SeriesDirectors_DirectorID",
                table: "SeriesDirectors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeriesCountries",
                table: "SeriesCountries");

            migrationBuilder.DropIndex(
                name: "IX_SeriesCountries_CountryID",
                table: "SeriesCountries");

            migrationBuilder.RenameColumn(
                name: "languageID",
                table: "SeriesLanguages",
                newName: "LanguagesID");

            migrationBuilder.RenameColumn(
                name: "DirectorID",
                table: "SeriesDirectors",
                newName: "DirectorsID");

            migrationBuilder.RenameColumn(
                name: "CountryID",
                table: "SeriesCountries",
                newName: "CountriesID");

            migrationBuilder.RenameColumn(
                name: "DirectorId",
                table: "MovieDirectors",
                newName: "MoviesID");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "MovieDirectors",
                newName: "DirectorsID");

            migrationBuilder.RenameIndex(
                name: "IX_MovieDirectors_DirectorId",
                table: "MovieDirectors",
                newName: "IX_MovieDirectors_MoviesID");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "EpisodeComments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeriesDirectors",
                table: "SeriesDirectors",
                columns: new[] { "DirectorsID", "SeriesID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeriesCountries",
                table: "SeriesCountries",
                columns: new[] { "CountriesID", "SeriesID" });

            migrationBuilder.CreateTable(
                name: "MovieCountries",
                columns: table => new
                {
                    CountriesID = table.Column<int>(type: "integer", nullable: false),
                    MoviesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCountries", x => new { x.CountriesID, x.MoviesID });
                    table.ForeignKey(
                        name: "FK_MovieCountries_Countries_CountriesID",
                        column: x => x.CountriesID,
                        principalTable: "Countries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCountries_Movies_MoviesID",
                        column: x => x.MoviesID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenres",
                columns: table => new
                {
                    GenresID = table.Column<int>(type: "integer", nullable: false),
                    MoviesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenres", x => new { x.GenresID, x.MoviesID });
                    table.ForeignKey(
                        name: "FK_MovieGenres_Genres_GenresID",
                        column: x => x.GenresID,
                        principalTable: "Genres",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenres_Movies_MoviesID",
                        column: x => x.MoviesID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieLanguages",
                columns: table => new
                {
                    LanguagesID = table.Column<int>(type: "integer", nullable: false),
                    MoviesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieLanguages", x => new { x.LanguagesID, x.MoviesID });
                    table.ForeignKey(
                        name: "FK_MovieLanguages_Languages_LanguagesID",
                        column: x => x.LanguagesID,
                        principalTable: "Languages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieLanguages_Movies_MoviesID",
                        column: x => x.MoviesID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieProducers",
                columns: table => new
                {
                    MoviesID = table.Column<int>(type: "integer", nullable: false),
                    ProducersID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieProducers", x => new { x.MoviesID, x.ProducersID });
                    table.ForeignKey(
                        name: "FK_MovieProducers_Movies_MoviesID",
                        column: x => x.MoviesID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieProducers_Producers_ProducersID",
                        column: x => x.ProducersID,
                        principalTable: "Producers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeriesProduceres",
                columns: table => new
                {
                    ProducersID = table.Column<int>(type: "integer", nullable: false),
                    SeriesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesProduceres", x => new { x.ProducersID, x.SeriesID });
                    table.ForeignKey(
                        name: "FK_SeriesProduceres_Producers_ProducersID",
                        column: x => x.ProducersID,
                        principalTable: "Producers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeriesProduceres_Series_SeriesID",
                        column: x => x.SeriesID,
                        principalTable: "Series",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeriesDirectors_SeriesID",
                table: "SeriesDirectors",
                column: "SeriesID");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesCountries_SeriesID",
                table: "SeriesCountries",
                column: "SeriesID");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeComments_EpisodeID",
                table: "EpisodeComments",
                column: "EpisodeID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCountries_MoviesID",
                table: "MovieCountries",
                column: "MoviesID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_MoviesID",
                table: "MovieGenres",
                column: "MoviesID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieLanguages_MoviesID",
                table: "MovieLanguages",
                column: "MoviesID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieProducers_ProducersID",
                table: "MovieProducers",
                column: "ProducersID");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesProduceres_SeriesID",
                table: "SeriesProduceres",
                column: "SeriesID");

            migrationBuilder.AddForeignKey(
                name: "FK_EpisodeComments_Episodes_EpisodeID",
                table: "EpisodeComments",
                column: "EpisodeID",
                principalTable: "Episodes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDirectors_Directors_DirectorsID",
                table: "MovieDirectors",
                column: "DirectorsID",
                principalTable: "Directors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDirectors_Movies_MoviesID",
                table: "MovieDirectors",
                column: "MoviesID",
                principalTable: "Movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesCountries_Countries_CountriesID",
                table: "SeriesCountries",
                column: "CountriesID",
                principalTable: "Countries",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesDirectors_Directors_DirectorsID",
                table: "SeriesDirectors",
                column: "DirectorsID",
                principalTable: "Directors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesLanguages_Languages_LanguagesID",
                table: "SeriesLanguages",
                column: "LanguagesID",
                principalTable: "Languages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
