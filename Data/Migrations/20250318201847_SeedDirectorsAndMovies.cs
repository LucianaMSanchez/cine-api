using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CineApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDirectorsAndMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "Id", "Country", "DirectorId", "Name" },
                values: new object[,]
                {
                    { 1, "USA", 1, "Titanic" },
                    { 2, "Argentina", 2, "El Secreto de Sus Ojos" },
                    { 3, "USA", 3, "Inception" },
                    { 4, "South Korea", 4, "Parasite" },
                    { 5, "Argentina", 5, "Relatos Salvajes" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
