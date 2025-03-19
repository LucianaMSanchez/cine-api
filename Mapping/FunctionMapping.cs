using cineApi.Dtos;
using cineApi.Entities;

namespace cineApi.Mapping;

public static class FunctionMapping
{
    public static Function ToEntity(this CreateFunctionDto function)
    {
        return new Function()
        {
            MovieId = function.MovieId,
            Price = function.Price,
            Date = function.Date,
            Time = function.Time
        };
    }
    public static Function ToEntity(this UpdateFunctionDto function, int id)
    {
        return new Function()
        {
            Id = id,
            MovieId = function.MovieId,
            Price = function.Price,
            Date = function.Date,
            Time = function.Time
        };
    }
    public static FunctionDto ToDto(this Function function)
    {
        return new FunctionDto
        {
            Id = function.Id,
            Price = function.Price,
            Date = function.Date,
            Time = function.Time,
        };

    }
    public static FunctionDto ToSummaryDto(this Function function)
    {
        return new FunctionDto
        {
            Id = function.Id,
            Price = function.Price,
            Date = function.Date,
            Time = function.Time,
            Movie = function.Movie!.Name,
            Director = function.Movie!.Director.Name
        };

    }
}