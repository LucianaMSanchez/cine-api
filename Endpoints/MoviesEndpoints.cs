using cineApi.Data;
using cineApi.Mapping;
using Microsoft.EntityFrameworkCore;

namespace cineApi.Endpoints
{
    public static class MoviesEndpoints
    {
        public static RouteGroupBuilder MapMoviesEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("movies").WithParameterValidation();

            group.MapGet("/", (CineApiContext dbContext) =>
                dbContext.Movies
                    .Include(movie => movie.Director)
                    .Include(movie => movie.Country)
                    .Select(movie => movie.ToSummaryDto())
                    .AsNoTracking()
                    .ToList()
            );

            group.MapGet("/{id}", (int id, CineApiContext dbContext) =>
            {
                var movie = dbContext.Movies
                    .Include(movie => movie.Director)
                    .Include(movie => movie.Country)
                    .FirstOrDefault(movie => movie.Id == id);

                return movie is null ? Results.NotFound() : Results.Ok(movie.ToDto());
            }).WithName("GetMovie");

            group.MapGet("/country/{country?}", (int? country, CineApiContext dbContext) =>
            {
                var moviesQuery = dbContext.Movies
                    .Include(movie => movie.Director)
                    .Include(movie => movie.Country)
                    .AsNoTracking();

                if (country.HasValue)
                {
                    moviesQuery = moviesQuery.Where(movie => movie.CountryId == country.Value);
                }
                else
                {
                    moviesQuery = moviesQuery.Where(movie => movie.CountryId != 1);
                }

                var movies = moviesQuery
                    .Select(movie => movie.ToSummaryDto())
                    .ToList();

                return movies.Count != 0 ? Results.Ok(movies) : Results.NotFound();
            });

            return group;
        }
    }
}
