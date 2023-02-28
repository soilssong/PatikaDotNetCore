using MediatR;

namespace BandAPIV3.Practicum.Core.Application.CQRS.Commands
{
    public class UpdateBandCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int GenreId { get; set; }

        public int MusicianId { get; set; }
    }
}
