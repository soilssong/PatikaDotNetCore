﻿using BandAPIV3.Practicum.Core.Application.CQRS.Commands;
using BandAPIV3.Practicum.Core.Application.CQRS.Queries;
using BandAPIV3.Practicum.Infrastructure.Tools;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace BandAPIV3.Practicum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult>Register(RegisterUserCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("", request);
        }




        [HttpPost("[action]")]
        public async Task<IActionResult> Login(CheckUserQueryRequest request)
        {
           var dto = await _mediator.Send(request);
            if (dto.IsExist)
            {
             
                return Created("", JwtTokenGenerator.GenerateToken(dto));
            }
            else
            {
                return BadRequest("kullancı adı veya şifre hatalı");
            }
         
        }
    }
}
