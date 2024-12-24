using ETicaretAPI.Application.CustomAttributes;
using ETicaretAPI.Application.Enums;
using ETicaretAPI.Application.Features.Commands.Role.CreateRole;
using ETicaretAPI.Application.Features.Commands.Role.DeleteRole;
using ETicaretAPI.Application.Features.Commands.Role.UpdateRole;
using ETicaretAPI.Application.Features.Queries.Role.GetRoles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Roles", Menu = "Roles")]
        public async Task<IActionResult> GetRoles([FromQuery] GetRolesQueryRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Role By Id", Menu = "Roles")]
        public async Task<IActionResult> GetRoleById([FromRoute] GetRolesQueryRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);

        }

        [HttpPost]
        [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Create Role", Menu = "Roles")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleQueryRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);

        }

        [HttpPut("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Role", Menu = "Roles")]
        public async Task<IActionResult> UpdateRole([FromBody, FromRoute] UpdateRoleQueryRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);

        }

        [HttpDelete]
        [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Delete Role", Menu = "Roles")]
        public async Task<IActionResult> DeleteRole([FromBody]DeleteRoleQueryRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);

        }
    }
}