using AutoMapper;
using Gym.Application.DTOs.Gym;
using Gym.Application.DTOs.Validations;
using Gym.Application.Interfaces;
using Gym.Domain.Entities;
using Gym.Domain.Interfaces;

namespace Gym.Application.Services
{
    public class GymService : IGymService
    {
        private readonly IGymRepository _repository;
        private readonly IMapper _mapper;

        public GymService(IGymRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ListResponse<GymDTO>> GetAllAsync()
        {
            var gyms = await _repository.GetAllAsync();
            var gymsToDto = _mapper.Map<IList<GymDTO>>(gyms);
            return ListResponse.Ok<GymDTO>(gymsToDto);
        }

        public async Task<ResultService<GymDTO>> GetByIdAsync(Guid id)
        {
            if (id == null)
            {
                return ResultService.Fail<GymDTO>("Id da academia deve ser informado!");
            }
            var gym = await _repository.GetById(id);
            if (gym == null)
            {
                return ResultService.Fail<GymDTO>($"Nenhuma academia encontrada com o Id: {id}!");
            }
     
            var gymToDto = _mapper.Map<GymDTO>(gym);
            var result = new GymDtoValidation().Validate(gymToDto);
            if (!result.IsValid)
            {
                return ResultService.RequestError<GymDTO>("Erro na requisição!", result);
            }
            return ResultService.Ok<GymDTO>(gymToDto, "Academia obtida com sucesso!");
        }

        public async Task<ResultService<GymDTO>> CreateAsync(CreateGymDTO createGymDTO)
        {
            var result = new CreateGymDtoValidation().Validate(createGymDTO);
            if (!result.IsValid)
            {
                return ResultService.RequestError<GymDTO>("Erros na requisição", result);
            }

            var gym = _mapper.Map<Domain.Entities.Gym>(createGymDTO);
            var createdGym = await _repository.CreateAsync(gym);
            return ResultService.Ok<GymDTO>(_mapper.Map<GymDTO>(createdGym), "Academia criada com sucesso!");
        }

        public async Task<ResultService<GymDTO>> UpdateAsync(GymDTO gymDto)
        {
            var validate = new GymDtoValidation().Validate(gymDto);
            if (!validate.IsValid)
            {
                return ResultService.RequestError<GymDTO>("Erros na requisição", validate);
            }

            var gym = await _repository.GetById(gymDto.Id);
            if (gym == null)
            {
                return ResultService.Fail<GymDTO>($"Nenhuma academia encontrada com o Id: {gymDto.Id}!");
            }

            var updateGym = await _repository.UpdateAsync(gym);
            return ResultService.Ok<GymDTO>(_mapper.Map<GymDTO>(updateGym), "Dados da academia alterados com sucesso!");
        }

        public async Task<ResultService<GymDTO>> DeleteAsync(Guid id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return ResultService.Fail<GymDTO>("Id da academia deve ser informado!");
            }

            var gym = await _repository.GetById(id);
            if (gym == null)
            {
                return ResultService.Fail<GymDTO>($"Nenhuma academia encontrada com o Id: {id}!");
            }
            
            await _repository.DeleteAsync(gym);
            return ResultService.Ok<GymDTO>(_mapper.Map<GymDTO>(gym), "Academia deletada com sucesso!");
        }
    }
}
