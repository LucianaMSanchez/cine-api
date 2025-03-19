namespace cineApi.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Country { get; set; }
        public required int DirectorId { get; set; }
        public required Director Director { get; set; }

    }

}