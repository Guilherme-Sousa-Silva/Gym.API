using Gym.Application.DTOs.Gym;
using Gym.Application.DTOs.Role;
using Gym.Application.Services;

namespace Gym.Application.Interfaces
{
    public interface IRoleService
    {
        Task<ListResponse<RoleDTO>> GetAllAsync();
        Task<ResultService<RoleDTO>> GetByIdAsync(Guid id);
        Task<ResultService<RoleDTO>> CreateAsync(CreateRoleDTO roleDTO);
        Task<ResultService<RoleDTO>> UpdateAsync(RoleDTO roleDTO);
        Task<ResultService<RoleDTO>> DeleteAsync(Guid id);
    }
}
