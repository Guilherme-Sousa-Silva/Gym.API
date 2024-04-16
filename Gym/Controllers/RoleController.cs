using Gym.Application.DTOs.Gym;
using Gym.Application.DTOs.Role;
using Gym.Application.Interfaces;
using Gym.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gym.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _roleService.GetAllAsync());
        }

        [HttpGet("get-by-id/{id:Guid}")]
        public async Task<IActionResult> GetAllAsync([FromRoute] Guid id)
        {
            return Ok(await _roleService.GetByIdAsync(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateRoleDTO dto)
        {
            return Ok(await _roleService.CreateAsync(dto));
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] RoleDTO dto)
        {
            return Ok(await _roleService.UpdateAsync(dto));
        }

        [HttpDelete("delete/{id:Guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            return Ok(await _roleService.DeleteAsync(id));
        }
    }
}
