using Gym.Domain.Enumerables;
using System.Text.Json.Serialization;

namespace Gym.Application.DTOs.Role
{
    public class CreateRoleDTO
    {
        public CreateRoleDTO(string name, ERoleType roleType)
        {
            Id = Guid.NewGuid();
            Name = name;
            RoleType = roleType;
        }

        [JsonIgnore]
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public ERoleType RoleType { get; private set; }
    }
}
