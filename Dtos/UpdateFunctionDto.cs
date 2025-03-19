using System.ComponentModel.DataAnnotations;

namespace cineApi.Dtos;

public record class UpdateFunctionDto(
    int MovieId,
    int DirectorId,
    [Range(1, 1000)] decimal Price,
    DateOnly Date,
    TimeSpan Time
);