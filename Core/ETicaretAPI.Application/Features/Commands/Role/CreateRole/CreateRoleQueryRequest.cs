using MediatR;

namespace ETicaretAPI.Application.Features.Commands.Role.CreateRole
{
    public class CreateRoleQueryRequest : IRequest<CreateRoleQueryResponse>
    {
        public string Name { get; set; }
    }
}
