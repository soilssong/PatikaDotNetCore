using BandAPI_V2_Business.Interfaces;
using BandAPI_V2_DTOS.BandDtos;
using Microsoft.AspNetCore.Mvc;

namespace BandAPI_V2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BandController : Controller
    {

        private readonly IBandService _bandService;

        public BandController(IBandService bandService)
        {
            _bandService = bandService;
        }

        [HttpGet]
        public IActionResult Product()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var bandsList = await _bandService.GetAll();
            return View(bandsList);
        }
    }
}
