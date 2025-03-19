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
                .Include(function => function.Movie)
                .ThenInclude(movie => movie!.Director)
                .Select(function => function.ToSummaryDto())
                .AsNoTracking()
            );


            group.MapGet("/{id}", (int id, CineApiContext dbContext) =>
            {
                Function? function = dbContext.Functions.Find(id);

                if (function is null)
                {
                    return Results.NotFound();
                }

                var movie = dbContext.Movies.Find(function.MovieId);
                var director = dbContext.Directors.Find(movie?.DirectorId);

                FunctionDto functionDto = function.ToDto();
                functionDto.Director = director?.Name;
                functionDto.Movie = movie?.Name;

                return Results.Ok(functionDto);

            }).WithName("GetFunction");


            group.MapPost("/", (CreateFunctionDto newFunction, CineApiContext dbContext) =>
            {
                Function function = newFunction.ToEntity();
                function.Movie = dbContext.Movies.Find(newFunction.MovieId);

                dbContext.Functions.Add(function);
                dbContext.SaveChanges();

                var director = dbContext.Directors.Find(function.Movie!.DirectorId);

                FunctionDto functionDto = function.ToDto();
                functionDto.Director = director!.Name;

                return Results.CreatedAtRoute("GetFunction", new { id = function.Id }, functionDto);
            }
            );

            group.MapPut("/{id}", (int id, UpdateFunctionDto newFunction, CineApiContext dbContext) =>
            {
                var existingFunction = dbContext.Functions.Find(id);

                if (existingFunction is null)
                {
                    return Results.NotFound();
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