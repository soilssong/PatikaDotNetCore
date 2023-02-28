using BandAPIV3.Practicum.Core.Application.Dtos;
using MediatR;

namespace BandAPIV3.Practicum.Core.Application.CQRS.Queries
{
    public class GetGenreQueryRequest :IRequest<GenreListDto>
    {

        public int Id { get; set; }

        public GetGenreQueryRequest(int id)
        {
            Id = id;
        }
    }
}
