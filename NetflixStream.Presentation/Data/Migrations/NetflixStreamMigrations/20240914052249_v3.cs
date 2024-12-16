using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetflixStream.Persistence.Data.Migrations.NetflixStreamMigrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieDirectors");

            migrationBuilder.DropTable(
                name: "MoviesCountries");

            migrationBuilder.DropTable(
                name: "MoviesGenres");

            migrationBuilder.DropTable(
                name: "MoviesLanguages");

            migrationBuilder.DropTable(
                name: "MoviesProducers");

            migrationBuilder.DropTable(
                name: "SeriesCountries");

            migrationBuilder.DropTable(
                name: "SeriesDirectors");

            migrationBuilder.DropTable(
                name: "SeriesGenres");

            migrationBuilder.DropTable(
                name: "SeriesLanguages");

            migrationBuilder.DropTable(
                name: "SeriesProducers");

            migrationBuilder.AlterColumn<string>(
                name: "PosterPath",
                table: "Movies",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.CreateTable(
                name: "CountryMovies",
                columns: table => new
                {
                    CountriesID = table.Column<int>(type: "integer", nullable: false),
                    MoviesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryMovies", x => new { x.CountriesID, x.MoviesID });
                    table.ForeignKey(
                        name: "FK_CountryMovies_Countries_CountriesID",
                        column: x => x.CountriesID,
                        principalTable: "Countries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryMovies_Movies_MoviesID",
                        column: x => x.MoviesID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountrySeries",
                columns: table => new
                {
                    CountriesID = table.Column<int>(type: "integer", nullable: false),
                    SeriesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountrySeries", x => new { x.CountriesID, x.SeriesID });
                    table.ForeignKey(
                        name: "FK_CountrySeries_Countries_CountriesID",
                        column: x => x.CountriesID,
                        principalTable: "Countries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountrySeries_Series_SeriesID",
                        column: x => x.SeriesID,
                        principalTable: "Series",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DirectorMovies",
                columns: table => new
                {
                    DirectorsID = table.Column<int>(type: "integer", nullable: false),
                    MoviesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectorMovies", x => new { x.DirectorsID, x.MoviesID });
                    table.ForeignKey(
                        name: "FK_DirectorMovies_Directors_DirectorsID",
                        column: x => x.DirectorsID,
                        principalTable: "Directors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DirectorMovies_Movies_MoviesID",
                        column: x => x.MoviesID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DirectorSeries",
                columns: table => new
                {
                    DirectorsID = table.Column<int>(type: "integer", nullable: false),
                    SeriesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectorSeries", x => new { x.DirectorsID, x.SeriesID });
                    table.ForeignKey(
                        name: "FK_DirectorSeries_Directors_DirectorsID",
                        column: x => x.DirectorsID,
                        principalTable: "Directors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DirectorSeries_Series_SeriesID",
                        column: x => x.SeriesID,
                        principalTable: "Series",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreMovies",
                columns: table => new
                {
                    GenresID = table.Column<int>(type: "integer", nullable: false),
                    MoviesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMovies", x => new { x.GenresID, x.MoviesID });
                    table.ForeignKey(
                        name: "FK_GenreMovies_Genres_GenresID",
                        column: x => x.GenresID,
                        principalTable: "Genres",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMovies_Movies_MoviesID",
                        column: x => x.MoviesID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreSeries",
                columns: table => new
                {
                    GenresID = table.Column<int>(type: "integer", nullable: false),
                    SeriesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreSeries", x => new { x.GenresID, x.SeriesID });
                    table.ForeignKey(
                        name: "FK_GenreSeries_Genres_GenresID",
                        column: x => x.GenresID,
                        principalTable: "Genres",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreSeries_Series_SeriesID",
                        column: x => x.SeriesID,
                        principalTable: "Series",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguageMovies",
                columns: table => new
                {
                    MoviesID = table.Column<int>(type: "integer", nullable: false),
                    languagesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageMovies", x => new { x.MoviesID, x.languagesID });
                    table.ForeignKey(
                        name: "FK_LanguageMovies_Languages_languagesID",
                        column: x => x.languagesID,
                        principalTable: "Languages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguageMovies_Movies_MoviesID",
                        column: x => x.MoviesID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguageSeries",
                columns: table => new
                {
                    SeriesID = table.Column<int>(type: "integer", nullable: false),
                    languagesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageSeries", x => new { x.SeriesID, x.languagesID });
                    table.ForeignKey(
                        name: "FK_LanguageSeries_Languages_languagesID",
                        column: x => x.languagesID,
                        principalTable: "Languages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguageSeries_Series_SeriesID",
                        column: x => x.SeriesID,
                        principalTable: "Series",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviesProducer",
                columns: table => new
                {
                    MoviesID = table.Column<int>(type: "integer", nullable: false),
                    ProducersID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesProducer", x => new { x.MoviesID, x.ProducersID });
                    table.ForeignKey(
                        name: "FK_MoviesProducer_Movies_MoviesID",
                        column: x => x.MoviesID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesProducer_Producers_ProducersID",
                        column: x => x.ProducersID,
                        principalTable: "Producers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProducerSeries",
                columns: table => new
                {
                    ProducersID = table.Column<int>(type: "integer", nullable: false),
                    SeriesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProducerSeries", x => new { x.ProducersID, x.SeriesID });
                    table.ForeignKey(
                        name: "FK_ProducerSeries_Producers_ProducersID",
                        column: x => x.ProducersID,
                        principalTable: "Producers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProducerSeries_Series_SeriesID",
                        column: x => x.SeriesID,
                        principalTable: "Series",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryMovies_MoviesID",
                table: "CountryMovies",
                column: "MoviesID");

            migrationBuilder.CreateIndex(
                name: "IX_CountrySeries_SeriesID",
                table: "CountrySeries",
                column: "SeriesID");

            migrationBuilder.CreateIndex(
                name: "IX_DirectorMovies_MoviesID",
                table: "DirectorMovies",
                column: "MoviesID");

            migrationBuilder.CreateIndex(
                name: "IX_DirectorSeries_SeriesID",
                table: "DirectorSeries",
                column: "SeriesID");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovies_MoviesID",
                table: "GenreMovies",
                column: "MoviesID");

            migrationBuilder.CreateIndex(
                name: "IX_GenreSeries_SeriesID",
                table: "GenreSeries",
                column: "SeriesID");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageMovies_languagesID",
                table: "LanguageMovies",
                column: "languagesID");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageSeries_languagesID",
                table: "LanguageSeries",
                column: "languagesID");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesProducer_ProducersID",
                table: "MoviesProducer",
                column: "ProducersID");

            migrationBuilder.CreateIndex(
                name: "IX_ProducerSeries_SeriesID",
                table: "ProducerSeries",
                column: "SeriesID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryMovies");

            migrationBuilder.DropTable(
                name: "CountrySeries");

            migrationBuilder.DropTable(
                name: "DirectorMovies");

            migrationBuilder.DropTable(
                name: "DirectorSeries");

            migrationBuilder.DropTable(
                name: "GenreMovies");

            migrationBuilder.DropTable(
                name: "GenreSeries");

            migrationBuilder.DropTable(
                name: "LanguageMovies");

            migrationBuilder.DropTable(
                name: "LanguageSeries");

            migrationBuilder.DropTable(
                name: "MoviesProducer");

            migrationBuilder.DropTable(
                name: "ProducerSeries");

            migrationBuilder.AlterColumn<string>(
                name: "PosterPath",
                table: "Movies",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "MovieDirectors",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "integer", nullable: false),
                    DirectorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDirectors", x => new { x.MovieId, x.DirectorId });
                    table.ForeignKey(
                        name: "FK_MovieDirectors_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieDirectors_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    MoviesID = table.Column<int>(type: "integer", nullable: false),
                    LanguageID = table.Column<int>(type: "integer", nullable: false)
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
                name: "SeriesCountries",
                columns: table => new
                {
                    SeriesID = table.Column<int>(type: "integer", nullable: false),
                    CountryID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesCountries", x => new { x.SeriesID, x.CountryID });
                    table.ForeignKey(
                        name: "FK_SeriesCountries_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeriesCountries_Series_SeriesID",
                        column: x => x.SeriesID,
                        principalTable: "Series",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeriesDirectors",
                columns: table => new
                {
                    SeriesID = table.Column<int>(type: "integer", nullable: false),
                    DirectorID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesDirectors", x => new { x.SeriesID, x.DirectorID });
                    table.ForeignKey(
                        name: "FK_SeriesDirectors_Directors_DirectorID",
                        column: x => x.DirectorID,
                        principalTable: "Directors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeriesDirectors_Series_SeriesID",
                        column: x => x.SeriesID,
                        principalTable: "Series",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeriesGenres",
                columns: table => new
                {
                    GenresID = table.Column<int>(type: "integer", nullable: false),
                    SeriesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesGenres", x => new { x.GenresID, x.SeriesID });
                    table.ForeignKey(
                        name: "FK_SeriesGenres_Genres_GenresID",
                        column: x => x.GenresID,
                        principalTable: "Genres",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeriesGenres_Series_SeriesID",
                        column: x => x.SeriesID,
                        principalTable: "Series",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeriesLanguages",
                columns: table => new
                {
                    languageID = table.Column<int>(type: "integer", nullable: false),
                    SeriesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesLanguages", x => new { x.languageID, x.SeriesID });
                    table.ForeignKey(
                        name: "FK_SeriesLanguages_Languages_languageID",
                        column: x => x.languageID,
                        principalTable: "Languages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeriesLanguages_Series_SeriesID",
                        column: x => x.SeriesID,
                        principalTable: "Series",
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
                name: "IX_MovieDirectors_DirectorId",
                table: "MovieDirectors",
                column: "DirectorId");

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
                name: "IX_SeriesCountries_CountryID",
                table: "SeriesCountries",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesDirectors_DirectorID",
                table: "SeriesDirectors",
                column: "DirectorID");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesGenres_SeriesID",
                table: "SeriesGenres",
                column: "SeriesID");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesLanguages_SeriesID",
                table: "SeriesLanguages",
                column: "SeriesID");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesProducers_SeriesID",
                table: "SeriesProducers",
                column: "SeriesID");
        }
    }
}
