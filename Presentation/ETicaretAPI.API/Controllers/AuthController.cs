using ETicaretAPI.Application.Features.Commands.AppUser.LoginUser;
using ETicaretAPI.Application.Features.Commands.AppUser.NewFolder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]

        public async Task<IActionResult> LoginUser([FromBody]LoginUserCommandRequest request)
        {
            LoginUserCommandResponse response = await _mediator.Send(request);

            return Ok(response);

        }

        [HttpPost("[action]")]

        public async Task<IActionResult> RefreshToken([FromBody]RefreshTokenLoginCommandRequest request )
        {
            RefreshTokenLoginCommandResponse response = await _mediator.Send(request);

            return Ok(response);

        }
    }
}
