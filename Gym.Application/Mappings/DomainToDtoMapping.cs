using AutoMapper;
using Gym.Application.DTOs.Gym;
using Gym.Application.DTOs.Role;
using Gym.Domain.Entities;

namespace Gym.Application.Mappings
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            // Gym
            CreateMap<Domain.Entities.Gym, GymDTO>().ReverseMap();
            CreateMap<Domain.Entities.Gym, CreateGymDTO>().ReverseMap();
            CreateMap<GymDTO, CreateGymDTO>().ReverseMap();

            // Roles
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Role, CreateRoleDTO>().ReverseMap();
        }
    }
}
