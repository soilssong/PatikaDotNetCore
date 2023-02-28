using AutoMapper;
using BandAPIV3.Practicum.Core.Application.CQRS.Queries;
using BandAPIV3.Practicum.Core.Application.Dtos;
using BandAPIV3.Practicum.Core.Application.Interfaces;
using BandAPIV3.Practicum.Core.Domain;
using MediatR;

namespace BandAPIV3.Practicum.Core.Application.CQRS.Handlers
{
    public class GetBandQueryHandler : IRequestHandler<GetBandQueryRequest,BandListDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Band> _repository;

        public GetBandQueryHandler(IMapper mapper, IRepository<Band> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<BandListDto> Handle(GetBandQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByFilterAsync(x => x.Id == request.Id);
            return _mapper.Map<BandListDto>(data);
        }
    }
}
