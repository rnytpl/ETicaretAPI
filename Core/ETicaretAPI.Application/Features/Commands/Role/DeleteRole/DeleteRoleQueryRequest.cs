using MediatR;

namespace ETicaretAPI.Application.Features.Commands.Role.DeleteRole
{
    public class DeleteRoleQueryRequest : IRequest<DeleteRoleQueryResponse>
    {
        public string Id { get; set; }
    }
}
