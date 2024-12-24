using ETicaretAPI.Application.DTOs.Endpoint;

namespace ETicaretAPI.Application.DTOs.Role
{
    public class RoleDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<EndpointDTO>? Endpoints { get; set; }
    }
}
