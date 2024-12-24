using ETicaretAPI.Application.Abstractions.Services.Configurations;
using ETicaretAPI.Application.Consts;
using ETicaretAPI.Application.CustomAttributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ApplicationServicesController : ControllerBase
    {
        IApplicationService _applicationService;

        public ApplicationServicesController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [AuthorizeDefinition( ActionType= Application.Enums.ActionType.Reading, Definition ="Get Authorize Definition Endpoints", Menu = AuthorizeDefinitionConstants.ApplicationServices)]
        public IActionResult AuthorizeDefinitionEndpoints()
        {
            var datas = _applicationService.GetAuthorizeDefinitionEndpoints(typeof(Program));

            return Ok(datas);
        }
    }
}
