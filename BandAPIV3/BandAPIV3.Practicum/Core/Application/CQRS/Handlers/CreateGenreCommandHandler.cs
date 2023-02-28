using BandAPIV3.Practicum.Core.Application.CQRS.Commands;
using BandAPIV3.Practicum.Core.Application.Interfaces;
using BandAPIV3.Practicum.Core.Domain;
using MediatR;

namespace BandAPIV3.Practicum.Core.Application.CQRS.Handlers
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommandRequest>
    {
        private readonly IRepository<Genre> _repository;

        public CreateGenreCommandHandler(IRepository<Genre> repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(CreateGenreCommandRequest request, CancellationToken cancellationToken)
        {

            await _repository.CreateAsync(new Genre
            {
                Name = request.Name,
             
            });
            return Unit.Value;
        }
    }
}
