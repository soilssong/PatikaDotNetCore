using AutoMapper;
using BandAPIV3.Practicum.Core.Application.CQRS.Queries;
using BandAPIV3.Practicum.Core.Application.Dtos;
using BandAPIV3.Practicum.Core.Application.Interfaces;
using BandAPIV3.Practicum.Core.Domain;
using MediatR;

namespace BandAPIV3.Practicum.Core.Application.CQRS.Handlers
{
    public class GetGenresQueryHandler : IRequestHandler<GetAllGenresQueryRequest, List<GenreListDto>>
    {
        private readonly IRepository<Genre> _repository;
        private readonly IMapper _mapper;

        public GetGenresQueryHandler(IMapper mapper, IRepository<Genre> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }



        public async Task<List<GenreListDto>> Handle(GetAllGenresQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<GenreListDto>>(data);
        }
    }
}
