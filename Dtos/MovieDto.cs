namespace cineApi.Dtos;

public class MovieDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? ImageProfileUrl { get; set; }
    public string? ImageSliderUrl { get; set; }
    public string? TrailerUrl { get; set; }
    public string? Country { get; set; }
    public string? Director { get; set; }
}