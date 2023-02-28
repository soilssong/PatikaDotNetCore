using BandAPIV3.Practicum.Core.Application.CQRS.Commands;
using BandAPIV3.Practicum.Core.Application.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BandAPIV3.Practicum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class GenreController : ControllerBase
    {

        private readonly IMediator _mediator;

        public GenreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> ListGenres()
        {
            var data = await _mediator.Send(new GetAllGenresQueryRequest());
            return Ok(data);
        }



        [HttpGet("{id}")]

        public async Task<IActionResult> GetGenre(int id)
        {
            var data = await _mediator.Send(new GetGenreQueryRequest(id));
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }



        [HttpPost]

        public async Task<IActionResult> CreateBand(CreateGenreCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("", request);
        }


        [HttpPut]

        public async Task<IActionResult> UpdateGenre(UpdateGenreCommandRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var data = await _mediator.Send(new DeleteGenreCommandRequest(id));
            return NoContent();
        }
    }


}
