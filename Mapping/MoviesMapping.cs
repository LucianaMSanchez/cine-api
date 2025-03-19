using cineApi.Dtos;
using cineApi.Entities;

namespace cineApi.Mapping;

public static class MoviesMapping
{
    public static MovieDto ToDto(this Movie movie)
    {
        return new MovieDto
        {
            Id = movie.Id,
            Name = movie.Name,
            Country = movie.Country.Name,
            Director = movie.Director.Name,
            ImageProfileUrl = movie.ImageProfileUrl,
            ImageSliderUrl = movie.ImageSliderUrl,
            TrailerUrl = movie.TrailerUrl
        };

    }
    public static MovieDto ToSummaryDto(this Movie movie)
    {
        return new MovieDto
        {
            Id = movie.Id,
            Name = movie.Name,
            Country = movie.Country.Name,
            Director = movie.Director.Name,
            ImageProfileUrl = movie.ImageProfileUrl,
            ImageSliderUrl = movie.ImageSliderUrl,
            TrailerUrl = movie.TrailerUrl
        };

    }
}