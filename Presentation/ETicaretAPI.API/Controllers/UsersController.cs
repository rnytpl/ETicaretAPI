using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.Features.Commands.AppUser.Createuser;
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

        [HttpGet]
        public async Task<IActionResult> ExampleMailTest()
        {
            await _mailService.SendMessageAsync("ronay.topal@icloud.com", "Örnek Mail", "<strong>Bu bir örnek maildir.</strong>");

            return Ok();

        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserCommandRequest request)
        {
            CreateUserCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }


    }
}
