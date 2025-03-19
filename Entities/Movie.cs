namespace cineApi.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required Country Country { get; set; }
        public required int DirectorId { get; set; }
        public required Director Director { get; set; }
        public required string ImageProfileUrl { get; set; }
        public required string ImageSliderUrl { get; set; }
        public required string TrailerUrl { get; set; }
        public required int CountryId { get; set; }
    }

}
