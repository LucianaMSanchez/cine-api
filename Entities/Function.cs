namespace cineApi.Entities
{
    public class Function
    {
        public int Id { get; set; }
        public required int MovieId { get; set; }
        public Movie? Movie { get; set; }
        public DateOnly Date { get; set; }
        public TimeSpan Time { get; set; }
        public decimal Price { get; set; }
    }
}