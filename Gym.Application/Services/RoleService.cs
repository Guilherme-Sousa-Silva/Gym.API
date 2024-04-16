using AutoMapper;
using FluentValidation;
using Gym.Application.DTOs.Gym;
using Gym.Application.DTOs.Role;
using Gym.Application.DTOs.Validations;
using Gym.Application.Interfaces;
using Gym.Domain.Entities;
using Gym.Domain.Interfaces;

namespace Gym.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ListResponse<RoleDTO>> GetAllAsync()
        {
            var roles = await _repository.GetAllAsync();
            var rolesDto = _mapper.Map<IList<RoleDTO>>(roles);
            return ListResponse.Ok<RoleDTO>(rolesDto);
        }

        public async Task<ResultService<RoleDTO>> GetByIdAsync(Guid id)
        {
            if (id == null)
            {
                return ResultService.Fail<RoleDTO>("Id da role deve ser informado!");
            }

            var role = await _repository.GetById(id);
            if (role == null)
            {
                return ResultService.Fail<RoleDTO>($"Nenhuma role encontrada com o Id: {id}!");
            }

            var roleDto = _mapper.Map<RoleDTO>(role);

            var result = new RoleDtoValidation().Validate(roleDto);
            if (!result.IsValid)
            {
                return ResultService.RequestError<RoleDTO>("Erro na requisição!", result);
            }

            return ResultService.Ok<RoleDTO>(roleDto, "Role obtida com sucesso!");
        }

        public async Task<ResultService<RoleDTO>> CreateAsync(CreateRoleDTO roleDTO)
        {
            var teste = ((int)roleDTO.RoleType);
            var validate = new CreateRoleDtoValidation().Validate(roleDTO);
            if (!validate.IsValid)
            {
                return ResultService.RequestError<RoleDTO>("Erros na requisição", validate);
            }

            var role = _mapper.Map<Role>(roleDTO);
            var createdRole = await _repository.CreateAsync(role);
            return ResultService.Ok<RoleDTO>(_mapper.Map<RoleDTO>(createdRole), "Role criada com sucesso!");
        }

        public async Task<ResultService<RoleDTO>> UpdateAsync(RoleDTO roleDTO)
        {
            var validate = new RoleDtoValidation().Validate(roleDTO);
            if (!validate.IsValid)
            {
                return ResultService.RequestError<RoleDTO>("Erros na requisição", validate);
            }

            var role = _mapper.Map<Role>(roleDTO);
            var updatedRole = await _repository.UpdateAsync(role);
            return ResultService.Ok<RoleDTO>(_mapper.Map<RoleDTO>(updatedRole), "Role criada com sucesso!");
        }

        public async Task<ResultService<RoleDTO>> DeleteAsync(Guid id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return ResultService.Fail<RoleDTO>("Id da role deve ser informada!");
            }

            var role = await _repository.GetById(id);
            if (role == null)
            {
                return ResultService.Fail<RoleDTO>($"Nenhuma role encontrada com o Id: {id}!");
            }

            await _repository.DeleteAsync(role);
            return ResultService.Ok<RoleDTO>(_mapper.Map<RoleDTO>(role), "Role deletada com sucesso!");
        }
    }
}
