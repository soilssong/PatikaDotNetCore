using MediatR;

namespace BandAPIV3.Practicum.Core.Application.CQRS.Commands
{
    public class DeleteBandCommandRequest : IRequest
    {
        public DeleteBandCommandRequest(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
