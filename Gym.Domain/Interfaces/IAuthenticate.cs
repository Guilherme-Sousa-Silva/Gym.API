using Gym.Domain.Entities;

namespace Gym.Domain.Interfaces
{
    public interface IAuthenticate
    {
        Task<bool> AuthenticateAsync(string email, string password);
        Task<bool> UserExist(string email);
        Task<string> GenerateToken(string email, Guid id);
        Task<User> GetUserByEmail(string email);
    }
}
