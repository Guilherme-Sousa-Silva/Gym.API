using AutoMapper;
using FluentValidation;
using Gym.Application.DTOs.Gym;
using Gym.Application.DTOs.User;
using Gym.Application.DTOs.Validations;
using Gym.Application.Interfaces;
using Gym.Domain.Entities;
using Gym.Domain.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Gym.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IAuthenticate _authenticate;

        public UserService(IUserRepository userRepository, IMapper mapper, IAuthenticate authenticate)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _authenticate = authenticate;
        }

        public async Task<ResultService<UserDTO>> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return ResultService.Fail<UserDTO>($"Nenhum usuário encontrado pelo Id: {id}!");
            }

            var userDto = _mapper.Map<UserDTO>(user);
            var result = new UserToDtoValidation().Validate(userDto);
            if (!result.IsValid)
            {
                return ResultService.RequestError<UserDTO>("Erros na requisição", result);
            }

            return ResultService.Ok<UserDTO>(userDto, "Usuário obtido com sucesso!");
        }

        public async Task<ResultService<UserDTO>> CreateAsync(CreateUserDTO createUserDTO)
        {
            var result = new CreateUserToDtoValidation().Validate(createUserDTO);
            if (!result.IsValid) {
                return ResultService.RequestError<UserDTO>("Erros na requisição!", result);
            }

            if (await _authenticate.UserExist(createUserDTO.Email))
            {
                return ResultService.Fail<UserDTO>("Email já cadastrado no sistema!");
            };

            using var hmac = new HMACSHA512();
            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(createUserDTO.PassWord));
            byte[] passwordSalt = hmac.Key;

            var user = _mapper.Map<User>(createUserDTO);

            user.SetPasswordHash(passwordHash, passwordSalt);

            var createdUser = await _userRepository.CreateAsync(user);
            return ResultService.Ok<UserDTO>(_mapper.Map<UserDTO>(createdUser), "Usuário criado com sucesso!");
        }
        public async Task<ResultService<UserDTO>> UpdateAsync(UserDTO userDTO)
        {
            var result = new UserToDtoValidation().Validate(userDTO);
            if (!result.IsValid)
            {
                return ResultService.RequestError<UserDTO>("Erros na requisição!", result);
            }

            var user = await GetByIdAsync(userDTO.Id);

            var userDto = _mapper.Map<User>(user);
            var updatedUser = await _userRepository.CreateAsync(userDto);
            return ResultService.Ok<UserDTO>(_mapper.Map<UserDTO>(updatedUser), "Usuário alterado com sucesso!");
        }

        public async Task<ResultService<UserDTO>> DeleteAsync(Guid id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return ResultService.Fail<UserDTO>("Id do usuário deve ser informado!");
            }

            var userDto = await GetByIdAsync(id);
            var user = _mapper.Map<User>(userDto);
            await _userRepository.DeleteAsync(user);
            return ResultService.Ok<UserDTO>(_mapper.Map<UserDTO>(user), "Usuário deletado com sucesso!");
        }
    }
}
