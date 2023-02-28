using MediatR;

namespace BandAPIV3.Practicum.Core.Application.CQRS.Commands
{
    public class UpdateGenreCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
