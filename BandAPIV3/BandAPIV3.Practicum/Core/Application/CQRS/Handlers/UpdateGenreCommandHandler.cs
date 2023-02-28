using BandAPIV3.Practicum.Core.Application.CQRS.Commands;
using BandAPIV3.Practicum.Core.Application.Interfaces;
using BandAPIV3.Practicum.Core.Domain;
using MediatR;

namespace BandAPIV3.Practicum.Core.Application.CQRS.Handlers
{
    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommandRequest>
    {
        private readonly IRepository<Genre> _repository;

        public UpdateGenreCommandHandler(IRepository<Genre> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateGenreCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedGenre = await _repository.GetByIdAsync(request.Id);

            if (updatedGenre != null)
            {
                updatedGenre.Name = request.Name;
            
                await _repository.UpdateAsync(updatedGenre);
            }
            return Unit.Value;
        }
    }
}
