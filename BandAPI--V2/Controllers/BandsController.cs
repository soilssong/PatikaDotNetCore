using BandAPI_V2_Business.Interfaces;
using BandAPI_V2_DTOS.BandDtos;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace BandAPI__V2.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BandsController : ControllerBase
    {
      
        private readonly IBandService _bandService;

        public BandsController(IBandService bandService)
        {
            _bandService = bandService;
       
        }

        [HttpGet]
        public async Task<ActionResult<List<BandListDto>>> GetBands()
        {
            var bandList = await _bandService.GetAll();
            return BadRequest(bandList);
            
        }

        [HttpGet]
        public async Task<ActionResult<BandDto>> GetBandsbyId(int id)
        {
            var bandList = await _bandService.GetById(id);
            return BadRequest(bandList);
        }

        [HttpDelete]
        public async Task RemoveBand(int id)
        {
            
            await _bandService.Remove(id);
        }


        [HttpPost]
        public async Task ICreateBand(BandCreateDto dto)
        {
            await _bandService.Create(dto);
        }


        [HttpPost]
        public async Task UpdateBand(BandUpdateDto dto)
        {
            await _bandService.UpdateBand(dto);
        }
    }
}