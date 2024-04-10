using Gym.Application.DTOs.Gym;
using Gym.Application.Services;

namespace Gym.Application.Interfaces
{
    public interface IGymService
    {
        Task<IList<GymDTO>> GetAllAsync();
        Task<ResultService<GymDTO>> GetByIdAsync(Guid id);
        Task<ResultService<GymDTO>> CreateAsync(CreateGymDTO createGymDTO);
        Task<ResultService<GymDTO>> UpdateAsync(GymDTO gymDto);
        Task<ResultService<GymDTO>> DeleteAsync(Guid id);
    }
}
