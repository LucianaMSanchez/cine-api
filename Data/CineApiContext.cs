using cineApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace cineApi.Data
{
    public class CineApiContext(DbContextOptions<CineApiContext> options)
    : DbContext(options)
    {
        public DbSet<Function> Functions => Set<Function>();
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Director> Directors => Set<Director>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Director>().HasData(
                new { Id = 1, Name = "James Cameron" },
                new { Id = 2, Name = "Juan José Campanella" },
                new { Id = 3, Name = "Christopher Nolan" },
                new { Id = 4, Name = "Bong Joon-ho" },
                new { Id = 5, Name = "Damián Szifron" }
            );
            modelBuilder.Entity<Movie>().HasData(
                new { Id = 1, Name = "Titanic", Country = "USA", DirectorId = 1 },
                new { Id = 2, Name = "El Secreto de Sus Ojos", Country = "Argentina", DirectorId = 2 },
                new { Id = 3, Name = "Inception", Country = "USA", DirectorId = 3 },
                new { Id = 4, Name = "Parasite", Country = "South Korea", DirectorId = 4 },
                new { Id = 5, Name = "Relatos Salvajes", Country = "Argentina", DirectorId = 5 }
            );
        }
    }
}