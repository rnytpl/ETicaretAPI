using ETicaretAPI.Application.Abstractions.Services;
using MediatR;

namespace ETicaretAPI.Application.Features.Commands.Role.DeleteRole
{
    public class DeleteRoleQueryHandler : IRequestHandler<DeleteRoleQueryRequest, DeleteRoleQueryResponse>
    {

        readonly IRoleService _roleService;
        public DeleteRoleQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<DeleteRoleQueryResponse> Handle(DeleteRoleQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _roleService.DeleteRole(request.Id);

            return new() { Succeeded = result};
        }
    }
}
