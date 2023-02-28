using BandAPIV3.Practicum.Core.Application.CQRS.Queries;
using BandAPIV3.Practicum.Core.Application.Dtos;
using BandAPIV3.Practicum.Core.Application.Interfaces;
using BandAPIV3.Practicum.Core.Domain;
using MediatR;

namespace BandAPIV3.Practicum.Core.Application.CQRS.Handlers
{
    public class CheckUserRequestHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
    {
        private readonly IRepository<AppUser> _userRepository;
        private readonly IRepository<AppRole> _roleRepository;

        public CheckUserRequestHandler(IRepository<AppUser> userRepository, IRepository<AppRole> roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserResponseDto();
            var user = await _userRepository.GetByFilterAsync(x => x.UserName == request.Username && x.Password == request.Password);

            if (user == null)
            {
                dto.IsExist = false;
            }
            else
            {

                dto.UserName = user.UserName;
                dto.Id = user.Id;
                dto.IsExist = true;
                var role = await _roleRepository.GetByFilterAsync(x => x.Id == user.AppRoleId);
                dto.Role = role.Definition;
            }
            return dto;
        }

    }
}
