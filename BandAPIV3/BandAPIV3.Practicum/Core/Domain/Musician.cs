namespace BandAPIV3.Practicum.Core.Domain
{
    public class Musician
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public List<Band> Bands;
    }
}
