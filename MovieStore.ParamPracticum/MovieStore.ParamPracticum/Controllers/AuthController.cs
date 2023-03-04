using Business.Interfaces;
using Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieStore.ParamPracticum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
    
        private readonly IUserService _authService;

        public AuthController(IUserService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (ModelState.IsValid)
            {
                await _authService.Create(dto);
                return Ok();
            }
            return BadRequest();
        }

       
        

    }
}
