
 using MediatR;
namespace BandAPIV3.Practicum.Core.Application.CQRS.Commands
{
    public class DeleteGenreCommandRequest : IRequest
{
    public int Id { get; set; }

    public DeleteGenreCommandRequest(int ıd)
    {
        Id = ıd;
    }
}
}

