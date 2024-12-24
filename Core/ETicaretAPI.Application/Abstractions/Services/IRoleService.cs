using ETicaretAPI.Application.DTOs.Role;

namespace ETicaretAPI.Application.Abstractions.Services
{
    public interface IRoleService
    {
        //IDictionary<string, string> GetAllRoles();
        List<RoleDTO> GetAllRoles();
        Task<(string id, string name)> GetRoleById(string id);
        Task<bool> CreateRole(string name);
        Task<bool> DeleteRole(string Id);
        Task<bool> UpdateRole(string id, string name);

    }
}
