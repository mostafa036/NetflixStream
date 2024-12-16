namespace NetflixStream.Application.DTOs.Movies
{
    public class MovieCreateDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Duration { get; set; }
        public int ReleaseDate { get; set; }
        public string AgeRating { get; set; } = string.Empty;
        public decimal IMDbRating { get; set; }
        public string Writer { get; set; } = string.Empty;
        public Dictionary<int, string> ActorCharacterNames { get; set; } = new Dictionary<int, string>();
        public List<int> GenreIds { get; set; } = new List<int>();
        public List<int> CountryIds { get; set; } = new List<int>();
        public List<int> LanguageIds { get; set; } = new List<int>();
        public List<int> DirectorIds { get; set; } = new List<int>();
        public List<int> ProducerIds { get; set; } = new List<int>();
    }
}
