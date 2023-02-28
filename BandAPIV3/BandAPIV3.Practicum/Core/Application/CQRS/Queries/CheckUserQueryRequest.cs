using BandAPIV3.Practicum.Core.Application.Dtos;
using MediatR;

namespace BandAPIV3.Practicum.Core.Application.CQRS.Queries
{
    public class CheckUserQueryRequest : IRequest<CheckUserResponseDto>
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
