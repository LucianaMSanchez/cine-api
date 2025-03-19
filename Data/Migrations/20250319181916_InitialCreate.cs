using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CineApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DirectorId = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageProfileUrl = table.Column<string>(type: "TEXT", nullable: false),
                    ImageSliderUrl = table.Column<string>(type: "TEXT", nullable: false),
                    TrailerUrl = table.Column<string>(type: "TEXT", nullable: false),
                    CountryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Functions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Time = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Functions_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Argentina" },
                    { 2, "USA" },
                    { 3, "South Korea" }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "James Cameron" },
                    { 2, "Juan José Campanella" },
                    { 3, "Christopher Nolan" },
                    { 4, "Bong Joon-ho" },
                    { 5, "Damián Szifron" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CountryId", "DirectorId", "ImageProfileUrl", "ImageSliderUrl", "Name", "TrailerUrl" },
                values: new object[,]
                {
                    { 1, 2, 1, "https://play-lh.googleusercontent.com/560-H8NVZRHk00g3RltRun4IGB-Ndl0I0iKy33D7EQ0cRRwH78-c46s90lZ1ho_F1so=w240-h480-rw", "https://i.ytimg.com/vi/A1FtRovJMxk/hq720.jpg?sqp=-oaymwEhCK4FEIIDSFryq4qpAxMIARUAAAAAGAElAADIQj0AgKJD&rs=AOn4CLDSDRGU7c9EGMuHNqhR9nbWEfFrrg", "Titanic", "https://www.youtube.com/embed/tA_qMdzvCvk" },
                    { 2, 1, 2, "https://m.media-amazon.com/images/S/pv-target-images/4396cc2ce854e81eb1ffa97433856cc866ebd2cb01f612746633a06dd52809a9.jpg", "https://media.lacapital.com.ar/p/076a7cefc44fa9a47d369b8ac08fbfb3/adjuntos/203/imagenes/006/451/0006451399/642x0/smart/01-11-el_secretojpg.jpg", "El Secreto de Sus Ojos", "https://www.youtube.com/embed/RQT0kH2oZxk" },
                    { 3, 2, 3, "https://play-lh.googleusercontent.com/buKf27Hxendp3tLNpNtP3E-amP0o4yYV-SGKyS2u-Y3GdGRTyfNCIT5WAVs2OudOz6so5K1jtYdAUKI9nw8", "https://beam-images.warnermediacdn.com/BEAM_LWM_DELIVERABLES/14552c93-d318-4563-a00b-343df7e35d0b/4beb5159-7570-4f7e-bd37-6f7ea0ccff52?host=wbd-images.prod-vod.h264.io&partner=beamcom", "Inception", "https://www.youtube.com/embed/OCEkhKvm-hU" },
                    { 4, 3, 4, "https://m.media-amazon.com/images/S/pv-target-images/fb4358b042adbf87a337f58bfc44ca6516388f7d6ed9c69f174cc71e473dab08.jpg", "https://beam-images.warnermediacdn.com/BEAM_LWM_DELIVERABLES/d5e3be11-eb8b-449f-89cf-db887ddee777/beda1820a916959baee657ba47d022f7a81e9d6b.jpg?host=wbd-images.prod-vod.h264.io&partner=beamcom", "Parasite", "https://www.youtube.com/embed/9kLlmWPilSE" },
                    { 5, 1, 5, "https://m.media-amazon.com/images/S/pv-target-images/63a68d24b5bc35a08cb94a5bec39a58f3b8056c586c68839c63cdc73abf08d71.jpg", "https://m.media-amazon.com/images/S/pv-target-images/c6a93a716d8983fbfd445e2be9425d53bb755554ac20d8a51fd8ad10c3fc3639.jpg", "Relatos Salvajes", "https://www.youtube.com/embed/3BxE9osMt5U" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Functions_MovieId",
                table: "Functions",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CountryId",
                table: "Movies",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies",
                column: "DirectorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Functions");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Directors");
        }
    }
}
