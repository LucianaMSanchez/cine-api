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
            modelBuilder.Entity<Country>().HasData(
                new { Id = 1, Name = "Argentina" },
                new { Id = 2, Name = "USA" },
                new { Id = 3, Name = "South Korea" }
            );
            modelBuilder.Entity<Movie>().HasData(
                new { Id = 1, Name = "Titanic", CountryId = 2, DirectorId = 1, ImageProfileUrl = "https://play-lh.googleusercontent.com/560-H8NVZRHk00g3RltRun4IGB-Ndl0I0iKy33D7EQ0cRRwH78-c46s90lZ1ho_F1so=w240-h480-rw", ImageSliderUrl = "https://i.ytimg.com/vi/A1FtRovJMxk/hq720.jpg?sqp=-oaymwEhCK4FEIIDSFryq4qpAxMIARUAAAAAGAElAADIQj0AgKJD&rs=AOn4CLDSDRGU7c9EGMuHNqhR9nbWEfFrrg", TrailerUrl = "https://www.youtube.com/embed/tA_qMdzvCvk" },
                new { Id = 2, Name = "El Secreto de Sus Ojos", CountryId = 1, DirectorId = 2, ImageProfileUrl = "https://m.media-amazon.com/images/S/pv-target-images/4396cc2ce854e81eb1ffa97433856cc866ebd2cb01f612746633a06dd52809a9.jpg", ImageSliderUrl = "https://media.lacapital.com.ar/p/076a7cefc44fa9a47d369b8ac08fbfb3/adjuntos/203/imagenes/006/451/0006451399/642x0/smart/01-11-el_secretojpg.jpg", TrailerUrl = "https://www.youtube.com/embed/RQT0kH2oZxk" },
                new { Id = 3, Name = "Inception", CountryId = 2, DirectorId = 3, ImageProfileUrl = "https://play-lh.googleusercontent.com/buKf27Hxendp3tLNpNtP3E-amP0o4yYV-SGKyS2u-Y3GdGRTyfNCIT5WAVs2OudOz6so5K1jtYdAUKI9nw8", ImageSliderUrl = "https://beam-images.warnermediacdn.com/BEAM_LWM_DELIVERABLES/14552c93-d318-4563-a00b-343df7e35d0b/4beb5159-7570-4f7e-bd37-6f7ea0ccff52?host=wbd-images.prod-vod.h264.io&partner=beamcom", TrailerUrl = "https://www.youtube.com/embed/OCEkhKvm-hU" },
                new { Id = 4, Name = "Parasite", CountryId = 3, DirectorId = 4, ImageProfileUrl = "https://m.media-amazon.com/images/S/pv-target-images/fb4358b042adbf87a337f58bfc44ca6516388f7d6ed9c69f174cc71e473dab08.jpg", ImageSliderUrl = "https://beam-images.warnermediacdn.com/BEAM_LWM_DELIVERABLES/d5e3be11-eb8b-449f-89cf-db887ddee777/beda1820a916959baee657ba47d022f7a81e9d6b.jpg?host=wbd-images.prod-vod.h264.io&partner=beamcom", TrailerUrl = "https://www.youtube.com/embed/9kLlmWPilSE" },
                new { Id = 5, Name = "Relatos Salvajes", CountryId = 1, DirectorId = 5, ImageProfileUrl = "https://m.media-amazon.com/images/S/pv-target-images/63a68d24b5bc35a08cb94a5bec39a58f3b8056c586c68839c63cdc73abf08d71.jpg", ImageSliderUrl = "https://m.media-amazon.com/images/S/pv-target-images/c6a93a716d8983fbfd445e2be9425d53bb755554ac20d8a51fd8ad10c3fc3639.jpg", TrailerUrl = "https://www.youtube.com/embed/3BxE9osMt5U" }
            );
        }
    }
}