using ETicaretAPI.Application.DTOs.Role;

namespace ETicaretAPI.Application.Features.Queries.Role.GetRoles
{
    public class GetRolesQueryResponse
    {
        //public IDictionary<string, string> Roles { get; set; }
        public List<RoleDTO> Roles { get; set; }
    }
}
