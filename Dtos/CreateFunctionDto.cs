using System.ComponentModel.DataAnnotations;

namespace cineApi.Dtos;

public record class CreateFunctionDto(
    int MovieId,
    int DirectorId,
    [Range(1, 1000)] decimal Price,
    DateOnly Date,
    TimeSpan Time
);