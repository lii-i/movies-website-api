using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace movie_website_api.Migrations
{
    /// <inheritdoc />
    public partial class RebuildForUniversalDto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchListUsers_VideoItems_IdVideoItem",
                table: "WatchListUsers");

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
                name: "VideoItems");

            migrationBuilder.RenameColumn(
                name: "IdVideoItem",
                table: "WatchListUsers",
                newName: "IdAnimeItem");

            migrationBuilder.RenameIndex(
                name: "IX_WatchListUsers_IdVideoItem",
                table: "WatchListUsers",
                newName: "IX_WatchListUsers_IdAnimeItem");

            migrationBuilder.CreateTable(
                name: "Animes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    MalId = table.Column<int>(type: "integer", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: false),
                    OriginalTitle = table.Column<string>(type: "text", nullable: true),
                    TitleEn = table.Column<string>(type: "text", nullable: true),
                    TitleJap = table.Column<string>(type: "text", nullable: true),
                    Synonyms = table.Column<List<string>>(type: "text[]", nullable: false),
                    Poster = table.Column<string>(type: "text", nullable: true),
                    PosterOriginal = table.Column<string>(type: "text", nullable: true),
                    Backdrop = table.Column<string>(type: "text", nullable: true),
                    Rating = table.Column<double>(type: "double precision", nullable: true),
                    AgeRating = table.Column<string>(type: "text", nullable: true),
                    Kind = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Season = table.Column<string>(type: "text", nullable: true),
                    Year = table.Column<int>(type: "integer", nullable: true),
                    AiredOn = table.Column<DateOnly>(type: "date", nullable: true),
                    ReleasedOn = table.Column<DateOnly>(type: "date", nullable: true),
                    Episodes = table.Column<int>(type: "integer", nullable: true),
                    EpisodesAired = table.Column<int>(type: "integer", nullable: true),
                    Duration = table.Column<int>(type: "integer", nullable: true),
                    Genres = table.Column<List<string>>(type: "text[]", nullable: false),
                    Director = table.Column<string>(type: "text", nullable: true),
                    Studios = table.Column<List<string>>(type: "text[]", nullable: false),
                    Cast = table.Column<List<string>>(type: "text[]", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DescriptionHtml = table.Column<string>(type: "text", nullable: true),
                    EmbedUrl = table.Column<string>(type: "text", nullable: true),
                    Screenshots = table.Column<List<string>>(type: "text[]", nullable: false),
                    Related = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_WatchListUsers_Animes_IdAnimeItem",
                table: "WatchListUsers",
                column: "IdAnimeItem",
                principalTable: "Animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchListUsers_Animes_IdAnimeItem",
                table: "WatchListUsers");

            migrationBuilder.DropTable(
                name: "Animes");

            migrationBuilder.RenameColumn(
                name: "IdAnimeItem",
                table: "WatchListUsers",
                newName: "IdVideoItem");

            migrationBuilder.RenameIndex(
                name: "IX_WatchListUsers_IdAnimeItem",
                table: "WatchListUsers",
                newName: "IX_WatchListUsers_IdVideoItem");

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
                name: "VideoItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AiredAt = table.Column<string>(type: "text", nullable: true),
                    AllStatus = table.Column<string>(type: "text", nullable: true),
                    AnimeDescription = table.Column<string>(type: "text", nullable: true),
                    AnimeKind = table.Column<string>(type: "text", nullable: true),
                    AnimePosterUrl = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Duration = table.Column<int>(type: "integer", nullable: true),
                    EpisodesAired = table.Column<int>(type: "integer", nullable: true),
                    EpisodesCount = table.Column<int>(type: "integer", nullable: true),
                    EpisodesTotal = table.Column<int>(type: "integer", nullable: true),
                    ImdbId = table.Column<string>(type: "text", nullable: true),
                    ImdbRating = table.Column<double>(type: "double precision", nullable: true),
                    ImdbVotes = table.Column<int>(type: "integer", nullable: true),
                    KinopoiskId = table.Column<string>(type: "text", nullable: true),
                    KinopoiskRating = table.Column<double>(type: "double precision", nullable: true),
                    KinopoiskVotes = table.Column<int>(type: "integer", nullable: true),
                    LastEpisode = table.Column<int>(type: "integer", nullable: true),
                    LastSeason = table.Column<int>(type: "integer", nullable: true),
                    Link = table.Column<string>(type: "text", nullable: false),
                    MinimalAge = table.Column<int>(type: "integer", nullable: true),
                    PosterUrl = table.Column<string>(type: "text", nullable: true),
                    PremiereRu = table.Column<string>(type: "text", nullable: true),
                    PremiereWorld = table.Column<string>(type: "text", nullable: true),
                    RatingMpaa = table.Column<string>(type: "text", nullable: true),
                    ReleasedAt = table.Column<string>(type: "text", nullable: true),
                    ShikimoriId = table.Column<string>(type: "text", nullable: true),
                    ShikimoriRating = table.Column<double>(type: "double precision", nullable: true),
                    ShikimoriVotes = table.Column<int>(type: "integer", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: false),
                    TitleEn = table.Column<string>(type: "text", nullable: true),
                    TitleOrig = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    WorldartLink = table.Column<string>(type: "text", nullable: true),
                    Year = table.Column<int>(type: "integer", nullable: false)
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
                    IdCountry = table.Column<int>(type: "integer", nullable: false),
                    IdVideoItem = table.Column<int>(type: "integer", nullable: false)
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
                    IdCountry = table.Column<int>(type: "integer", nullable: false),
                    IdVideoItem = table.Column<int>(type: "integer", nullable: false),
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

            migrationBuilder.AddForeignKey(
                name: "FK_WatchListUsers_VideoItems_IdVideoItem",
                table: "WatchListUsers",
                column: "IdVideoItem",
                principalTable: "VideoItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
