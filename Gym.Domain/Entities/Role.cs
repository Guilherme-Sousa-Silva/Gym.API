using Gym.Domain.Enumerables;

namespace Gym.Domain.Entities
{
    public class Role
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public ERoleType RoleType { get; private set; }
        public IList<User> Users { get; private set; }
    }
}
