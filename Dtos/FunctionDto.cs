namespace cineApi.Dtos;

public class FunctionDto
{
    public int Id { get; set; }
    public string? Movie { get; set; }
    public decimal Price { get; set; }
    public DateOnly Date { get; set; }
    public TimeSpan Time { get; set; }
    public string? Director { get; set; }
}