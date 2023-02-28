using MediatR;

namespace BandAPIV3.Practicum.Core.Application.CQRS.Commands
{
    public class RegisterUserCommandRequest : IRequest
    {

        public string Username { get; set; }
        public string Password { get; set; }    
    }
}
