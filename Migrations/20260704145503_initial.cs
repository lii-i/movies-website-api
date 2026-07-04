using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace movie_website_api.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimeStudios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeStudios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CountryName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    AvatarPath = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    TitleOrig = table.Column<string>(type: "text", nullable: false),
                    TitleEn = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    KinopoiskId = table.Column<string>(type: "text", nullable: true),
                    ImdbId = table.Column<string>(type: "text", nullable: true),
                    ShikimoriId = table.Column<string>(type: "text", nullable: true),
                    WorldartLink = table.Column<string>(type: "text", nullable: true),
                    Link = table.Column<string>(type: "text", nullable: false),
                    LastSeason = table.Column<int>(type: "integer", nullable: true),
                    LastEpisode = table.Column<int>(type: "integer", nullable: true),
                    EpisodesCount = table.Column<int>(type: "integer", nullable: true),
                    AnimeKind = table.Column<string>(type: "text", nullable: true),
                    AllStatus = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    AnimeDescription = table.Column<string>(type: "text", nullable: true),
                    PosterUrl = table.Column<string>(type: "text", nullable: true),
                    AnimePosterUrl = table.Column<string>(type: "text", nullable: true),
                    Duration = table.Column<int>(type: "integer", nullable: true),
                    KinopoiskRating = table.Column<double>(type: "double precision", nullable: true),
                    KinopoiskVotes = table.Column<int>(type: "integer", nullable: true),
                    ImdbRating = table.Column<double>(type: "double precision", nullable: true),
                    ImdbVotes = table.Column<int>(type: "integer", nullable: true),
                    ShikimoriRating = table.Column<double>(type: "double precision", nullable: true),
                    ShikimoriVotes = table.Column<int>(type: "integer", nullable: true),
                    PremiereRu = table.Column<string>(type: "text", nullable: true),
                    PremiereWorld = table.Column<string>(type: "text", nullable: true),
                    AiredAt = table.Column<string>(type: "text", nullable: true),
                    ReleasedAt = table.Column<string>(type: "text", nullable: true),
                    RatingMpaa = table.Column<string>(type: "text", nullable: true),
                    MinimalAge = table.Column<int>(type: "integer", nullable: true),
                    EpisodesTotal = table.Column<int>(type: "integer", nullable: true),
                    EpisodesAired = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActorsVideo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdActors = table.Column<int>(type: "integer", nullable: false),
                    IdVideoItem = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorsVideo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActorsVideo_Actors_IdActors",
                        column: x => x.IdActors,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorsVideo_VideoItems_IdVideoItem",
                        column: x => x.IdVideoItem,
                        principalTable: "VideoItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimeStudiosVideo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdAnimeStudio = table.Column<int>(type: "integer", nullable: false),
                    IdVideoItem = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeStudiosVideo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimeStudiosVideo_AnimeStudios_IdAnimeStudio",
                        column: x => x.IdAnimeStudio,
                        principalTable: "AnimeStudios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeStudiosVideo_VideoItems_IdVideoItem",
                        column: x => x.IdVideoItem,
                        principalTable: "VideoItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlockedCountries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdVideoItem = table.Column<int>(type: "integer", nullable: false),
                    IdCountry = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockedCountries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlockedCountries_Countries_IdCountry",
                        column: x => x.IdCountry,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlockedCountries_VideoItems_IdVideoItem",
                        column: x => x.IdVideoItem,
                        principalTable: "VideoItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlockedSeasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdVideoItem = table.Column<int>(type: "integer", nullable: false),
                    IdCountry = table.Column<int>(type: "integer", nullable: false),
                    Season = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockedSeasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlockedSeasons_Countries_IdCountry",
                        column: x => x.IdCountry,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlockedSeasons_VideoItems_IdVideoItem",
                        column: x => x.IdVideoItem,
                        principalTable: "VideoItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DirectorsVideo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdDirectors = table.Column<int>(type: "integer", nullable: false),
                    IdVideoItem = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectorsVideo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DirectorsVideo_Directors_IdDirectors",
                        column: x => x.IdDirectors,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DirectorsVideo_VideoItems_IdVideoItem",
                        column: x => x.IdVideoItem,
                        principalTable: "VideoItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProducersVideo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdProducers = table.Column<int>(type: "integer", nullable: false),
                    IdVideoItem = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProducersVideo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProducersVideo_Producers_IdProducers",
                        column: x => x.IdProducers,
                        principalTable: "Producers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProducersVideo_VideoItems_IdVideoItem",
                        column: x => x.IdVideoItem,
                        principalTable: "VideoItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Screenshots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdVideoItem = table.Column<int>(type: "integer", nullable: false),
                    URL = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screenshots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Screenshots_VideoItems_IdVideoItem",
                        column: x => x.IdVideoItem,
                        principalTable: "VideoItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoCountries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCountry = table.Column<int>(type: "integer", nullable: false),
                    IdVideoItem = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoCountries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoCountries_Countries_IdCountry",
                        column: x => x.IdCountry,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoCountries_VideoItems_IdVideoItem",
                        column: x => x.IdVideoItem,
                        principalTable: "VideoItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdGenres = table.Column<int>(type: "integer", nullable: false),
                    IdVideoItem = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoGenres_Genres_IdGenres",
                        column: x => x.IdGenres,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoGenres_VideoItems_IdVideoItem",
                        column: x => x.IdVideoItem,
                        principalTable: "VideoItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WatchListUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdVideoItem = table.Column<int>(type: "integer", nullable: false),
                    IdUser = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchListUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WatchListUsers_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WatchListUsers_VideoItems_IdVideoItem",
                        column: x => x.IdVideoItem,
                        principalTable: "VideoItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorsVideo_IdActors",
                table: "ActorsVideo",
                column: "IdActors");

            migrationBuilder.CreateIndex(
                name: "IX_ActorsVideo_IdVideoItem",
                table: "ActorsVideo",
                column: "IdVideoItem");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeStudiosVideo_IdAnimeStudio",
                table: "AnimeStudiosVideo",
                column: "IdAnimeStudio");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeStudiosVideo_IdVideoItem",
                table: "AnimeStudiosVideo",
                column: "IdVideoItem");

            migrationBuilder.CreateIndex(
                name: "IX_BlockedCountries_IdCountry",
                table: "BlockedCountries",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_BlockedCountries_IdVideoItem",
                table: "BlockedCountries",
                column: "IdVideoItem");

            migrationBuilder.CreateIndex(
                name: "IX_BlockedSeasons_IdCountry",
                table: "BlockedSeasons",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_BlockedSeasons_IdVideoItem",
                table: "BlockedSeasons",
                column: "IdVideoItem");

            migrationBuilder.CreateIndex(
                name: "IX_DirectorsVideo_IdDirectors",
                table: "DirectorsVideo",
                column: "IdDirectors");

            migrationBuilder.CreateIndex(
                name: "IX_DirectorsVideo_IdVideoItem",
                table: "DirectorsVideo",
                column: "IdVideoItem");

            migrationBuilder.CreateIndex(
                name: "IX_ProducersVideo_IdProducers",
                table: "ProducersVideo",
                column: "IdProducers");

            migrationBuilder.CreateIndex(
                name: "IX_ProducersVideo_IdVideoItem",
                table: "ProducersVideo",
                column: "IdVideoItem");

            migrationBuilder.CreateIndex(
                name: "IX_Screenshots_IdVideoItem",
                table: "Screenshots",
                column: "IdVideoItem");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCountries_IdCountry",
                table: "VideoCountries",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCountries_IdVideoItem",
                table: "VideoCountries",
                column: "IdVideoItem");

            migrationBuilder.CreateIndex(
                name: "IX_VideoGenres_IdGenres",
                table: "VideoGenres",
                column: "IdGenres");

            migrationBuilder.CreateIndex(
                name: "IX_VideoGenres_IdVideoItem",
                table: "VideoGenres",
                column: "IdVideoItem");

            migrationBuilder.CreateIndex(
                name: "IX_WatchListUsers_IdUser",
                table: "WatchListUsers",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_WatchListUsers_IdVideoItem",
                table: "WatchListUsers",
                column: "IdVideoItem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorsVideo");

            migrationBuilder.DropTable(
                name: "AnimeStudiosVideo");

            migrationBuilder.DropTable(
                name: "BlockedCountries");

            migrationBuilder.DropTable(
                name: "BlockedSeasons");

            migrationBuilder.DropTable(
                name: "DirectorsVideo");

            migrationBuilder.DropTable(
                name: "ProducersVideo");

            migrationBuilder.DropTable(
                name: "Screenshots");

            migrationBuilder.DropTable(
                name: "VideoCountries");

            migrationBuilder.DropTable(
                name: "VideoGenres");

            migrationBuilder.DropTable(
                name: "WatchListUsers");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "AnimeStudios");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VideoItems");
        }
    }
}
