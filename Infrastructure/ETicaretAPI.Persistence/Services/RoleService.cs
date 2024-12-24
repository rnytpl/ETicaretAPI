using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs.Endpoint;
using ETicaretAPI.Application.DTOs.Role;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Persistence.Services
{
    public class RoleService : IRoleService
    {

        readonly RoleManager<AppRole> _roleManager;
        readonly IEndpointReadRepository _endpointReadRepository;

        public RoleService(RoleManager<AppRole> roleManager, IEndpointReadRepository endpointReadRepository)
        {
            _roleManager = roleManager;
            _endpointReadRepository = endpointReadRepository;
        }
        public List<RoleDTO> GetAllRoles()
        {
            var roles = _roleManager.Roles.Include(r => r.Endpoints);

            return roles.Select(role => new RoleDTO
            {
                Id = role.Id,
                Name = role.Name,
                Endpoints = role.Endpoints.Where(e => e != null).Select(e => new EndpointDTO{
                
                    Id = e.Id.ToString(),
                    ActionType = e.ActionType,
                    Code = e.Code,
                    Definition = e.Definition,
                }).ToList()
            }).ToList();

            
        }

        public async Task<bool> CreateRole(string name)
        {
            IdentityResult result = await _roleManager.CreateAsync(new() { 
                Id = Guid.NewGuid().ToString(),
                Name = name});

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }

            return result.Succeeded;
        }

        public async Task<bool> DeleteRole(string Id)
        {
            
            IdentityResult result = await _roleManager.DeleteAsync(new() { Id = Id});

            return result.Succeeded;
        }

        public async Task<bool> UpdateRole(string id,string name)
        {
            IdentityResult result = await _roleManager.UpdateAsync(new() { Id = id, Name = name });

            return result.Succeeded;
        }

        //public IDictionary<string, string?> GetAllRoles()
        //{
        //    return _roleManager.Roles.ToDictionary(role => role.Id, role => role.Name);
        //}


        public async Task<(string id, string name)> GetRoleById(string id)
        {
            string role = await _roleManager.GetRoleIdAsync(new() { Id = id});

            return (id, role);
        }
    }
}
