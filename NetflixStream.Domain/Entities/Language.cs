

namespace NetflixStream.Domain.Entities
{
    public class Language : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Movies> Movies { get; set; } = new List<Movies>();
        public ICollection<Series> Series { get; set; } = new List<Series>();
    }
}
