using BandAPIV3.Practicum.Core.Application.CQRS.Commands;
using BandAPIV3.Practicum.Core.Application.Interfaces;
using BandAPIV3.Practicum.Core.Domain;
using MediatR;

namespace BandAPIV3.Practicum.Core.Application.CQRS.Handlers
{
    public class UpdateBandCommandHandler : IRequestHandler<UpdateBandCommandRequest>
    {
        private readonly IRepository<Band> _repository;

        public UpdateBandCommandHandler(IRepository<Band> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateBandCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedBand = await _repository.GetByIdAsync(request.Id);

            if (updatedBand != null)
            {
                updatedBand.Name = request.Name;
                updatedBand.MusicianId = request.MusicianId;
                updatedBand.GenreId = request.GenreId;
               await _repository.UpdateAsync(updatedBand);
            }
            return Unit.Value;
        }
    }
}
