using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NetflixStream.Persistence.Data.Migrations.NetflixStreamMigrations
{
    /// <inheritdoc />
    public partial class v1_NetflixStreamMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<int>(type: "integer", nullable: false),
                    Nationality = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Biography = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    PhotoPath = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Gender = table.Column<char>(type: "character(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    ReleaseDate = table.Column<int>(type: "integer", nullable: false),
                    CommentCount = table.Column<int>(type: "integer", nullable: false),
                    WatchCount = table.Column<int>(type: "integer", nullable: false),
                    AgeRating = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    IMDbRating = table.Column<decimal>(type: "numeric(3,1)", nullable: false),
                    Writer = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    PosterPath = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Seasons = table.Column<int>(type: "integer", nullable: false),
                    Episodes = table.Column<int>(type: "integer", nullable: false),
                    WatchCount = table.Column<int>(type: "integer", nullable: false),
                    FirstAired = table.Column<DateOnly>(type: "date", nullable: false),
                    LastAired = table.Column<DateOnly>(type: "date", nullable: false),
                    AgeRating = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Writer = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IMDbRating = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MovieActors",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "integer", nullable: false),
                    ActorId = table.Column<int>(type: "integer", nullable: false),
                    CharacterName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActors", x => new { x.MovieId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_MovieActors_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActors_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieComments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserEmail = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    MovieID = table.Column<int>(type: "integer", nullable: false),
                    CommentText = table.Column<string>(type: "text", nullable: false),
                    CommentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieComments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MovieComments_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "MovieDirectors",
                columns: table => new
                {
                    DirectorsID = table.Column<int>(type: "integer", nullable: false),
                    MoviesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDirectors", x => new { x.DirectorsID, x.MoviesID });
                    table.ForeignKey(
                        name: "FK_MovieDirectors_Directors_DirectorsID",
                        column: x => x.DirectorsID,
                        principalTable: "Directors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieDirectors_Movies_MoviesID",
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
                name: "MoviePhotos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Url = table.Column<string>(type: "text", nullable: false),
                    MovieId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviePhotos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MoviePhotos_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovieReviews",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserEmail = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    UserName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MovieID = table.Column<int>(type: "integer", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    ReviewText = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieReviews", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MovieReviews_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieStores",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TrailerPath = table.Column<string>(type: "text", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    MoviesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieStores", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MovieStores_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovieWatchingHistories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserEmail = table.Column<string>(type: "text", nullable: false),
                    MovieID = table.Column<int>(type: "integer", nullable: false),
                    StartWatching = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndWatching = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastWatchedPosition = table.Column<TimeSpan>(type: "interval", nullable: true),
                    WatchCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieWatchingHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MovieWatchingHistories_Movies_MovieID",
                        column: x => x.MovieID,
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
                name: "Episodes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SeriesId = table.Column<int>(type: "integer", nullable: false),
                    SeasonNumber = table.Column<int>(type: "integer", nullable: true),
                    EpisodeNumber = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    FilePath = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    AirDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CommentCount = table.Column<int>(type: "integer", nullable: false),
                    WatchCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Episodes_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeriesActors",
                columns: table => new
                {
                    SeriesId = table.Column<int>(type: "integer", nullable: false),
                    ActorId = table.Column<int>(type: "integer", nullable: false),
                    CharacterName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesActors", x => new { x.SeriesId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_SeriesActors_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeriesActors_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeriesCountries",
                columns: table => new
                {
                    CountriesID = table.Column<int>(type: "integer", nullable: false),
                    SeriesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesCountries", x => new { x.CountriesID, x.SeriesID });
                    table.ForeignKey(
                        name: "FK_SeriesCountries_Countries_CountriesID",
                        column: x => x.CountriesID,
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
                    DirectorsID = table.Column<int>(type: "integer", nullable: false),
                    SeriesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesDirectors", x => new { x.DirectorsID, x.SeriesID });
                    table.ForeignKey(
                        name: "FK_SeriesDirectors_Directors_DirectorsID",
                        column: x => x.DirectorsID,
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
                    LanguagesID = table.Column<int>(type: "integer", nullable: false),
                    SeriesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesLanguages", x => new { x.LanguagesID, x.SeriesID });
                    table.ForeignKey(
                        name: "FK_SeriesLanguages_Languages_LanguagesID",
                        column: x => x.LanguagesID,
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

            migrationBuilder.CreateTable(
                name: "EpisodeComments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserEmail = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    UserName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    EpisodeID = table.Column<int>(type: "integer", nullable: false),
                    CommentText = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CommentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeComments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EpisodeComments_Episodes_EpisodeID",
                        column: x => x.EpisodeID,
                        principalTable: "Episodes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EpisodePhotos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Url = table.Column<string>(type: "text", nullable: false),
                    PosterPath = table.Column<string>(type: "text", nullable: false),
                    EpisodeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodePhotos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EpisodePhotos_Episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EpisodeWatchingHistories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserEmail = table.Column<string>(type: "text", nullable: false),
                    SeriesID = table.Column<int>(type: "integer", nullable: false),
                    EpisodeID = table.Column<int>(type: "integer", nullable: true),
                    StartWatching = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndWatching = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastWatchedPosition = table.Column<TimeSpan>(type: "interval", nullable: true),
                    WatchCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeWatchingHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EpisodeWatchingHistories_Episodes_EpisodeID",
                        column: x => x.EpisodeID,
                        principalTable: "Episodes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_EpisodeWatchingHistories_Series_SeriesID",
                        column: x => x.SeriesID,
                        principalTable: "Series",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EpisodStores",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TrailerPath = table.Column<string>(type: "text", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    EpisodeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodStores", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EpisodStores_Episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeComments_EpisodeID",
                table: "EpisodeComments",
                column: "EpisodeID");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodePhotos_EpisodeId",
                table: "EpisodePhotos",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_SeriesId",
                table: "Episodes",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeWatchingHistories_EpisodeID",
                table: "EpisodeWatchingHistories",
                column: "EpisodeID");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeWatchingHistories_SeriesID",
                table: "EpisodeWatchingHistories",
                column: "SeriesID");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodStores_EpisodeId",
                table: "EpisodStores",
                column: "EpisodeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieActors_ActorId",
                table: "MovieActors",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieComments_MovieID",
                table: "MovieComments",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCountries_MoviesID",
                table: "MovieCountries",
                column: "MoviesID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieDirectors_MoviesID",
                table: "MovieDirectors",
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
                name: "IX_MoviePhotos_MovieId",
                table: "MoviePhotos",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieProducers_ProducersID",
                table: "MovieProducers",
                column: "ProducersID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieReviews_MovieID",
                table: "MovieReviews",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieStores_MoviesId",
                table: "MovieStores",
                column: "MoviesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieWatchingHistories_MovieID",
                table: "MovieWatchingHistories",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesActors_ActorId",
                table: "SeriesActors",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesCountries_SeriesID",
                table: "SeriesCountries",
                column: "SeriesID");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesDirectors_SeriesID",
                table: "SeriesDirectors",
                column: "SeriesID");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesGenres_SeriesID",
                table: "SeriesGenres",
                column: "SeriesID");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesLanguages_SeriesID",
                table: "SeriesLanguages",
                column: "SeriesID");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesProduceres_SeriesID",
                table: "SeriesProduceres",
                column: "SeriesID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EpisodeComments");

            migrationBuilder.DropTable(
                name: "EpisodePhotos");

            migrationBuilder.DropTable(
                name: "EpisodeWatchingHistories");

            migrationBuilder.DropTable(
                name: "EpisodStores");

            migrationBuilder.DropTable(
                name: "MovieActors");

            migrationBuilder.DropTable(
                name: "MovieComments");

            migrationBuilder.DropTable(
                name: "MovieCountries");

            migrationBuilder.DropTable(
                name: "MovieDirectors");

            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropTable(
                name: "MovieLanguages");

            migrationBuilder.DropTable(
                name: "MoviePhotos");

            migrationBuilder.DropTable(
                name: "MovieProducers");

            migrationBuilder.DropTable(
                name: "MovieReviews");

            migrationBuilder.DropTable(
                name: "MovieStores");

            migrationBuilder.DropTable(
                name: "MovieWatchingHistories");

            migrationBuilder.DropTable(
                name: "SeriesActors");

            migrationBuilder.DropTable(
                name: "SeriesCountries");

            migrationBuilder.DropTable(
                name: "SeriesDirectors");

            migrationBuilder.DropTable(
                name: "SeriesGenres");

            migrationBuilder.DropTable(
                name: "SeriesLanguages");

            migrationBuilder.DropTable(
                name: "SeriesProduceres");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
