using MediatR;

namespace ETicaretAPI.Application.Features.Queries.AuthorizationEndpoint.GetEndpointRoles
{
    public class GetEndpointRolesQueryRequest : IRequest<GetEndpointRolesQueryResponse>
    {
        public string Id { get; set; }
    }
}
