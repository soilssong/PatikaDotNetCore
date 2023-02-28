using BandAPIV3.Practicum.Core.Application.CQRS.Commands;
using BandAPIV3.Practicum.Core.Application.Enums;
using BandAPIV3.Practicum.Core.Application.Interfaces;
using BandAPIV3.Practicum.Core.Domain;
using MediatR;

namespace BandAPIV3.Practicum.Core.Application.CQRS.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest>
    {
        private readonly IRepository<AppUser> _repository;

        public RegisterUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AppUser
            {
                Password = request.Password,
                UserName = request.Username,
                AppRoleId = (int)RoleType.Member,
            });
            return Unit.Value;
        }
    }
}
