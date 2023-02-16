using AutoMapper;
using BandAPIV2.Business.Interfaces;
using BandAPIV2.Dto.BandDtos;
using Microsoft.AspNetCore.Mvc;


namespace BandAPIV2.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BandController : Controller
    {
        private readonly IBandService _bandService;
       
        public BandController(IBandService bandService)
        {
            _bandService = bandService;
        
        }

        [HttpGet]
        public async Task<ActionResult<List<BandListDto>>> GetBands()
        {
            var bandList = await _bandService.GetAll();
            return Ok(bandList);

        }

        [HttpGet]
        public async Task<ActionResult<BandListDto>> GetBandsbyId(int id)
        {
            var bandList = await _bandService.GetById(id);
            return BadRequest(bandList);
        }

        


        [HttpPost]
        public async Task<IActionResult> Create (BandCreateDto dto)
        {
        
           
                await _bandService.Create(dto);
                return Ok();
             

            
        }

       
        [HttpPut]
        public async Task<IActionResult> Update(BandUpdateDto dto)
        {
           
                await _bandService.Update(dto);
                return Ok();
            

           
        }

        [HttpDelete]

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _bandService.Remove(id);

            if (response.ResponseType == Common.ResponseObjects.ResponseType.NotFound)
            {
                return BadRequest(response.Message);
            }
            else
            {
                return Ok(response.Message);
            }


        
           
        }






    }
}
