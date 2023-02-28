using MediatR;

namespace BandAPIV3.Practicum.Core.Application.CQRS.Commands
{
    public class CreateBandCommandRequest : IRequest
    {


        public string? Name { get; set; }

        public int GenreId { get; set; }

        public int MusicianId { get; set; }
    }
}
