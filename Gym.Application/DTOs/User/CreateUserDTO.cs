using System.Text.Json.Serialization;

namespace Gym.Application.DTOs.User
{
    public class CreateUserDTO
    {
        public CreateUserDTO(string name, string email, string passWord, string confirmPassword, Guid roleId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            PassWord = passWord;
            ConfirmPassword = confirmPassword;
            RoleId = roleId;
        }

        [JsonIgnore]
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PassWord { get; set; }
        public string ConfirmPassword { get; set; }
        public Guid RoleId { get; set; }
    }
}
