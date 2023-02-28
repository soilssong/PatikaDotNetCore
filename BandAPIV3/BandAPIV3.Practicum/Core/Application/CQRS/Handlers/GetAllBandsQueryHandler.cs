using AutoMapper;
using BandAPIV3.Practicum.Core.Application.CQRS.Queries;
using BandAPIV3.Practicum.Core.Application.Dtos;
using BandAPIV3.Practicum.Core.Application.Interfaces;
using BandAPIV3.Practicum.Core.Domain;
using MediatR;

namespace BandAPIV3.Practicum.Core.Application.CQRS.Handlers
{
    public class GetAllBandsQueryHandler : IRequestHandler<GetAllBandsQueryRequest, List<BandListDto>>
    {
        private readonly IRepository<Band> _repository;
        private readonly IMapper _mapper;

        public GetAllBandsQueryHandler(IRepository<Band> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<BandListDto>> Handle(GetAllBandsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<BandListDto>>(data);
        }
    }
}
