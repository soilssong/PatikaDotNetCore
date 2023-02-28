using MediatR;

namespace BandAPIV3.Practicum.Core.Application.CQRS.Commands
{
    public class CreateGenreCommandRequest : IRequest
    {
        public string? Name { get; set; }
    }
}
