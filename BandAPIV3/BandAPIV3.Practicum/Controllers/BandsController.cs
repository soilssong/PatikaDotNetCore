using BandAPIV3.Practicum.Core.Application.CQRS.Commands;
using BandAPIV3.Practicum.Core.Application.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BandAPIV3.Practicum.Controllers
{
    [Authorize(Roles="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class BandsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BandsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]

        public async Task<IActionResult>List()
        {
          var data =  await _mediator.Send(new GetAllBandsQueryRequest());
            return Ok(data);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetBand(int id)
        {
            var data = await _mediator.Send(new GetBandQueryRequest(id));
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBand(int id)
        {
            var data = await _mediator.Send(new DeleteBandCommandRequest(id));
            return NoContent();
        }

        [HttpPost]

        public async Task<IActionResult> CreateBand(CreateBandCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("", request);
        }

        [HttpPut]

        public async Task<IActionResult> Update(UpdateBandCommandRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }


    }
}
