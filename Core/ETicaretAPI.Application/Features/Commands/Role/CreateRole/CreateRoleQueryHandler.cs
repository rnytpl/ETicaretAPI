using ETicaretAPI.Application.Abstractions.Services;
using MediatR;

namespace ETicaretAPI.Application.Features.Commands.Role.CreateRole
{
    public class CreateRoleQueryHandler : IRequestHandler<CreateRoleQueryRequest, CreateRoleQueryResponse>
    {

        readonly IRoleService _roleService;
        public CreateRoleQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<CreateRoleQueryResponse> Handle(CreateRoleQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _roleService.CreateRole(request.Name);

            return new() { Succeeded = result};
        }
    }
}
