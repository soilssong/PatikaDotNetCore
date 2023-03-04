using AutoMapper;
using Business.Interfaces;
using Dtos.MovieDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieStore.ParamPracticum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
       
        public MovieController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
       
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movieList = await _movieService.GetAll();
            return Ok(movieList);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById( int id)
        {
            var dto = await _movieService.GetById(id);
            return Ok(dto);
        }

        [HttpPost]

        public async Task<IActionResult> CreateBand(MovieCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                await _movieService.Create(dto);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]

        public async Task<IActionResult> UpdateBand(MovieUpdateDto dto)
        {
            if (ModelState.IsValid)
            {
                await _movieService.Update(dto);
                return Ok();
            }
            return BadRequest();
        }


        [HttpDelete]

        public async Task<IActionResult> Remove(int id)
        {
            await _movieService.Remove(id);
            return Ok();
        }


    }
}
