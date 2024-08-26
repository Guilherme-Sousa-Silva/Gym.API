namespace Gym.Domain.Entities
{
    public class User
    {
        public User(string name, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public Guid RoleId { get; set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }
        public Role Role { get; private set; }

        public void SetPasswordHash(byte[] passwordHash, byte[] passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

        public bool Validate(User user)
        {
            if (user == null) return false;
            if (string.IsNullOrEmpty(user.Name)) return false;
            if (string.IsNullOrEmpty(user.Email)) return false;

            return true;
        }
    }
}
