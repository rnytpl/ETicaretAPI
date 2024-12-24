using ETicaretAPI.Application.Abstractions.Services;
using MediatR;

namespace ETicaretAPI.Application.Features.Queries.AuthorizationEndpoint.GetEndpointRoles
{
    public class GetEndpointRolesQueryHandler : IRequestHandler<GetEndpointRolesQueryRequest, GetEndpointRolesQueryResponse>
    {
        readonly IAuthorizationEndpointService _authorizationEndpointService;

        public GetEndpointRolesQueryHandler(IAuthorizationEndpointService authorizationEndpointService)
        {
            _authorizationEndpointService = authorizationEndpointService;
        }

        public async Task<GetEndpointRolesQueryResponse> Handle(GetEndpointRolesQueryRequest request, CancellationToken cancellationToken)
        {
            var datas = await _authorizationEndpointService.GetRolesToEndpointAsync(request.Id);

            return new() { Roles = datas };
        }
    }
}
