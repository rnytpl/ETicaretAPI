using ETicaretAPI.Application.Abstractions.Services;
using MediatR;

namespace ETicaretAPI.Application.Features.Commands.Role.UpdateRole
{
    public class UpdateRoleQueryHandler : IRequestHandler<UpdateRoleQueryRequest, UpdateRoleQueryResponse>
    {

        readonly IRoleService _roleService;
        public UpdateRoleQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<UpdateRoleQueryResponse> Handle(UpdateRoleQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _roleService.UpdateRole(request.Id, request.Name);

            return new() { Succeeded = result};
        }
    }
}
