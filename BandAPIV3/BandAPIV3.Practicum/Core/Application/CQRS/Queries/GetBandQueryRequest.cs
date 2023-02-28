using BandAPIV3.Practicum.Core.Application.Dtos;
using MediatR;

namespace BandAPIV3.Practicum.Core.Application.CQRS.Queries
{
    public class GetBandQueryRequest : IRequest<BandListDto>
    {
        public int Id { get; set; }

        public GetBandQueryRequest(int id)
        {
            Id = id;
        }

        
    }
}
