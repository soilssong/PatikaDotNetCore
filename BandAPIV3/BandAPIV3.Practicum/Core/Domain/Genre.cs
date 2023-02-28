namespace BandAPIV3.Practicum.Core.Domain
{
    public class Genre
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public List<Band>? Bands { get; set; }
    }
}
