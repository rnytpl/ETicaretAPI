using ETicaretAPI.Application.Features.Commands.AuthorizationEndpoint.AssignRoleEndpoint;
using ETicaretAPI.Application.Features.Queries.AuthorizationEndpoint.GetEndpointRoles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationEndpointsController : ControllerBase
    {

        readonly IMediator _mediator;

        public AuthorizationEndpointsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Id}")]

        public async Task<IActionResult> GetEndpointRoles([FromRoute]GetEndpointRolesQueryRequest request)
        {
            GetEndpointRolesQueryResponse response =  await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AssignRoleEndpointCommandRequest request)
        {

            request.Type = typeof(Program);
            AssignRoleEndpointCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
