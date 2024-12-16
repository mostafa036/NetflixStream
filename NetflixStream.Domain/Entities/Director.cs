namespace NetflixStream.Domain.Entities
{
    public class Director : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Movies> Movies { get; set; } = new HashSet<Movies>();
        public ICollection<Series> Series { get; set; } = new HashSet<Series>();
    }
}
