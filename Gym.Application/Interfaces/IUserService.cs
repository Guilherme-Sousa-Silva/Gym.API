using Gym.Application.DTOs.User;
using Gym.Application.Services;

namespace Gym.Application.Interfaces
{
    public interface IUserService
    {
        Task<ResultService<UserDTO>> GetByIdAsync(Guid id);
        Task<ResultService<UserDTO>> CreateAsync(UserDTO createGymDTO);
        Task<ResultService<UserDTO>> UpdateAsync(UserDTO userDTO);
        Task<ResultService<UserDTO>> DeleteAsync(Guid id);
    }
}
