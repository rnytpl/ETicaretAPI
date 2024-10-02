using ETicaretAPI.Application.Features.Commands.AppUser.Createuser;
using ETicaretAPI.Application.Features.Commands.AppUser.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserCommandRequest request)
        {
            CreateUserCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("[action]")]
    
        public async Task<IActionResult> LoginUser([FromBody]LoginUserCommandRequest request)
        {
            LoginUserCommandResponse response = await _mediator.Send(request);

            return Ok(response);

        }

    }
}
