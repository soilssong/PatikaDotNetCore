namespace BandAPIV3.Practicum.Core.Domain
{
    public class Band
    {
        public int Id { get; set; }

        public string? Name { get; set; }


        public Genre? Genre { get; set; }

        public int GenreId { get; set; }

        public Musician? Musician { get; set; }
        public int MusicianId { get; set; }
    }
}
