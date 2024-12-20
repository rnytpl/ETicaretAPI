﻿using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.Features.Commands.AppUser.Createuser;
using ETicaretAPI.Application.Features.Commands.AppUser.UpdatePassword;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly IMailService _mailService;
        public UsersController(IMediator mediator, IMailService mailService)
        {
            _mediator = mediator;
            _mailService = mailService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserCommandRequest request)
        {
            CreateUserCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("update-password")]

        public async Task<IActionResult> UpdatePassword([FromBody]UpdatePasswordCommandRequest request)
        {
            UpdatePasswordCommandResponse response =  await _mediator.Send(request);

            return Ok(response);
        }

    }
}
