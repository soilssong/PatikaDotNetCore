using BandAPIV3.Practicum.Core.Application.CQRS.Commands;
using BandAPIV3.Practicum.Core.Application.Interfaces;
using BandAPIV3.Practicum.Core.Domain;
using MediatR;

namespace BandAPIV3.Practicum.Core.Application.CQRS.Handlers
{
    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommandRequest>
    {
        private readonly IRepository<Genre> _repository;

        public DeleteGenreCommandHandler(IRepository<Genre> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteGenreCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await _repository.GetByIdAsync(request.Id);

            if (deletedEntity != null)
            {
                await _repository.RemoveAsync(deletedEntity);
            }
            return Unit.Value;
        }
    }
}
