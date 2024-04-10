using Gym.Application.DTOs.Gym;
using Gym.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gym.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymController : ControllerBase
    {
        private readonly IGymService _Gymservice;

        public GymController(IGymService gymservice)
        {
            _Gymservice = gymservice;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _Gymservice.GetAllAsync());
        }

        [HttpGet("get-by-id/{id:Guid}")]
        public async Task<IActionResult> getByIdAsync(
            [FromRoute] Guid id)
        {
            return Ok(await _Gymservice.GetByIdAsync(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateGymDTO dto)
        {
            return Ok(await _Gymservice.CreateAsync(dto));
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] GymDTO dto)
        {
            return Ok(await _Gymservice.UpdateAsync(dto));
        }

        [HttpDelete("delete/{id:Guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            return Ok(await _Gymservice.DeleteAsync(id));
        }
    }
}