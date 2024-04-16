using Gym.Domain.Enumerables;

namespace Gym.Application.DTOs.Role
{
    public class RoleDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ERoleType RoleType { get; set; }
    }
}
