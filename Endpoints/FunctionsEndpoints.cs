using cineApi.Data;
using cineApi.Dtos;
using cineApi.Entities;
using cineApi.Mapping;
using Microsoft.EntityFrameworkCore;

namespace cineApi.Endpoints
{
    public static class FunctionsEndpoints
    {
        public static RouteGroupBuilder MapFunctionsEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("functions").WithParameterValidation();

            group.MapGet("/", (CineApiContext dbContext) =>
                dbContext.Functions
                    .Include(f => f.Movie)
                    .ThenInclude(m => m!.Director)
                    .AsNoTracking()
                    .ToList()
                    .GroupBy(f => f.Movie!.Name)
                    .Select(group => new
                    {
                        MovieName = group.Key,
                        Functions = group.Select(f => f.ToSummaryDto()).ToList()
                    })
                    .ToList()
            );

            group.MapGet("/{id}", (int id, CineApiContext dbContext) =>
            {
                var function = dbContext.Functions
                    .Include(f => f.Movie)
                    .ThenInclude(m => m!.Director)
                    .FirstOrDefault(f => f.Id == id);

                return function is null ? Results.NotFound() : Results.Ok(function.ToDto());
            }).WithName("GetFunction");

            group.MapGet("/movie/{movieId}", (int movieId, CineApiContext dbContext) =>
            {
                var functions = dbContext.Functions
                    .Where(f => f.MovieId == movieId)
                    .Include(f => f.Movie)
                    .ThenInclude(m => m!.Director)
                    .Select(f => f.ToSummaryDto())
                    .AsNoTracking()
                    .ToList();

                return functions.Count != 0 ? Results.Ok(functions) : Results.NotFound();
            });

            group.MapPost("/", (CreateFunctionDto newFunction, CineApiContext dbContext) =>
            {
                var currentDate = DateTime.Now;
                if (newFunction.Date < DateOnly.FromDateTime(currentDate) ||
                    (newFunction.Date == DateOnly.FromDateTime(currentDate) && newFunction.Time <= currentDate.TimeOfDay))
                {
                    return Results.BadRequest("The function date and time must be in the future.");
                }

                var directorFunctionsCount = dbContext.Functions
                    .Where(f => f.Movie!.DirectorId == newFunction.DirectorId && f.Date == newFunction.Date)
                    .Count();

                if (directorFunctionsCount >= 10)
                {
                    return Results.BadRequest("The director already has the maximum number of 10 functions for the day.");
                }

                var movie = dbContext.Movies.Include(m => m.Director).FirstOrDefault(m => m.Id == newFunction.MovieId);
                if (movie is null)
                {
                    return Results.BadRequest("The movie does not exist.");
                }

                if (movie.CountryId != 1 && dbContext.Functions
                    .Where(f => f.MovieId == newFunction.MovieId && f.Date == newFunction.Date)
                    .Count() >= 8)
                {
                    return Results.BadRequest("International movies are limited to 8 functions per day.");
                }

                Function function = newFunction.ToEntity();
                function.Movie = dbContext.Movies.Find(newFunction.MovieId);

                dbContext.Functions.Add(function);
                dbContext.SaveChanges();

                var director = dbContext.Directors.Find(function.Movie!.DirectorId);

                FunctionDto functionDto = function.ToDto();
                functionDto.Director = director!.Name;

                return Results.CreatedAtRoute("GetFunction", new { id = function.Id }, functionDto);
            });

            group.MapPut("/{id}", (int id, UpdateFunctionDto newFunction, CineApiContext dbContext) =>
            {
                var existingFunction = dbContext.Functions.Find(id);

                if (existingFunction is null)
                {
                    return Results.NotFound();
                }

                var currentDate = DateTime.Now;
                if (newFunction.Date < DateOnly.FromDateTime(currentDate) ||
                    (newFunction.Date == DateOnly.FromDateTime(currentDate) && newFunction.Time <= currentDate.TimeOfDay))
                {
                    return Results.BadRequest("The function date and time must be in the future.");
                }

                var directorFunctionsCount = dbContext.Functions
                    .Where(f => f.Movie!.DirectorId == newFunction.DirectorId && f.Date == newFunction.Date && f.Id != id)
                    .Count();

                if (directorFunctionsCount >= 10)
                {
                    return Results.BadRequest("The director already has the maximum number of 10 functions for the day.");
                }

                var movie = dbContext.Movies.Include(m => m.Director).FirstOrDefault(m => m.Id == newFunction.MovieId);
                if (movie is null)
                {
                    return Results.BadRequest("The movie does not exist.");
                }

                if (movie.CountryId != 1 && dbContext.Functions
                    .Where(f => f.MovieId == newFunction.MovieId && f.Date == newFunction.Date && f.Id != id)
                    .Count() >= 8)
                {
                    return Results.BadRequest("International movies are limited to 8 functions per day.");
                }

                dbContext.Entry(existingFunction).CurrentValues.SetValues(newFunction.ToEntity(id));

                dbContext.SaveChanges();
                return Results.NoContent();
            });

            group.MapDelete("/{id}", (int id, CineApiContext dbContext) =>
            {
                dbContext.Functions
                .Where(function => function.Id == id)
                .ExecuteDelete();

                return Results.NoContent();
            });

            return group;
        }
    }
}