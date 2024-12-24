using MediatR;

namespace ETicaretAPI.Application.Features.Commands.Role.UpdateRole
{
    public class UpdateRoleQueryRequest : IRequest<UpdateRoleQueryResponse>
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }
}
