namespace Gym.Application.DTOs.User
{
    public class UserDTO
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public Guid RoleId { get; set; }
    }
}
