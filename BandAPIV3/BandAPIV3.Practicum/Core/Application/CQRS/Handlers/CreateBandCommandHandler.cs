using BandAPIV3.Practicum.Core.Application.CQRS.Commands;
using BandAPIV3.Practicum.Core.Application.Interfaces;
using BandAPIV3.Practicum.Core.Domain;
using MediatR;

namespace BandAPIV3.Practicum.Core.Application.CQRS.Handlers
{
    public class CreateBandCommandHandler : IRequestHandler<CreateBandCommandRequest>
    {
        private readonly IRepository<Band> _repository;

        public CreateBandCommandHandler(IRepository<Band> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateBandCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Band
            {
                Name = request.Name,
                GenreId = request.GenreId,
                MusicianId = request.MusicianId
            });
            return Unit.Value;
        }
    }
}
