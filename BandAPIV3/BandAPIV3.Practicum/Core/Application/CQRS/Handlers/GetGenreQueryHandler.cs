using AutoMapper;
using BandAPIV3.Practicum.Core.Application.CQRS.Queries;
using BandAPIV3.Practicum.Core.Application.Dtos;
using BandAPIV3.Practicum.Core.Application.Interfaces;
using BandAPIV3.Practicum.Core.Domain;
using MediatR;

namespace BandAPIV3.Practicum.Core.Application.CQRS.Handlers
{
    public class GetGenreQueryHandler : IRequestHandler<GetGenreQueryRequest, GenreListDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Genre> _repository;

        public GetGenreQueryHandler(IMapper mapper, IRepository<Genre> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<GenreListDto> Handle(GetGenreQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByFilterAsync(x => x.Id == request.Id);
            return _mapper.Map<GenreListDto>(data);
        }
    }
}
