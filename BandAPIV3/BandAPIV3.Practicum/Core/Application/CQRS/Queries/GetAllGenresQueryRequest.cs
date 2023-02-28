using BandAPIV3.Practicum.Core.Application.Dtos;
using MediatR;

namespace BandAPIV3.Practicum.Core.Application.CQRS.Queries
{
    public class GetAllGenresQueryRequest : IRequest<List<GenreListDto>>
    {
    }
}
