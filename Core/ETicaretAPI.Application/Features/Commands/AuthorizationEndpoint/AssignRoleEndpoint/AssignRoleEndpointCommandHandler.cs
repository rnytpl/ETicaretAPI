using ETicaretAPI.Application.Abstractions.Services;
using MediatR;

namespace ETicaretAPI.Application.Features.Commands.AuthorizationEndpoint.AssignRoleEndpoint
{
    public class AssignRoleEndpointCommandHandler : IRequestHandler<AssignRoleEndpointCommandRequest, AssignRoleEndpointCommandResponse>
    {

        readonly IAuthorizationEndpointService _authorizationEndpointService;

        public AssignRoleEndpointCommandHandler(IAuthorizationEndpointService authorizationEndpointService)
        {
            _authorizationEndpointService = authorizationEndpointService;
        }

        public async Task<AssignRoleEndpointCommandResponse> Handle(AssignRoleEndpointCommandRequest request, CancellationToken cancellationToken)
        {

            try
            {
                await _authorizationEndpointService.AssignRoleEndpointAsync(request.Roles, request.Menu, request.Code, request.Type);

                return new AssignRoleEndpointCommandResponse
                {
                    Success = true,
                };
            }
            catch (Exception ex)
            {
                // Log exception if necessary
                return new AssignRoleEndpointCommandResponse
                {
                    Success = false,

                };
            }
        }
    }
}
 