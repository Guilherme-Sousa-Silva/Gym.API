using Gym.Domain.Enumerables;

namespace Gym.Domain.Entities
{
    public class Role
    {
        public Role(string name, ERoleType roleType)
        {
            Id = Guid.NewGuid();
            Name = name;
            RoleType = roleType;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public ERoleType RoleType { get; private set; }
        public IList<User> Users { get; private set; }

        public bool Validate(Role role)
        {
            if (role == null) return false;
            if (string.IsNullOrEmpty(role.Name)) return false;
            if (role.RoleType == null) return false;

            return true;
        }
    }
}
