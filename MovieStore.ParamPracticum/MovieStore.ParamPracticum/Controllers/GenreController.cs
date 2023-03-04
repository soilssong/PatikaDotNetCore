using Business.Interfaces;
using DataAccess.Interfaces;
using Dtos.GenreDtos;
using Entities.Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieStore.ParamPracticum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var genre = await _genreService.GetAll();
            return Ok(genre);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var genre = await _genreService.GetById(id);

            return Ok(genre);
        }

          
        
        [HttpDelete]

        public async Task<IActionResult> Remove(int id)
        {
            await _genreService.Remove(id);
            return Ok();
        }

        [HttpPost]

        public async Task<IActionResult> CreateGenre(GenreCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                await _genreService.Create(dto);
                return Ok();
            }
            return BadRequest();
        }



        [HttpPut]

        public async Task<IActionResult> UpdateBand(GenreUpdateDto dto)
        {
            if (ModelState.IsValid)
            {
                await _genreService.Update(dto);
                return Ok();
            }
            return BadRequest();
        }

    }
}
