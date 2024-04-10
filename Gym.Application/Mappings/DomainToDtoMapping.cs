using AutoMapper;
using Gym.Application.DTOs.Gym;

namespace Gym.Application.Mappings
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Domain.Entities.Gym, GymDTO>().ReverseMap();
            CreateMap<Domain.Entities.Gym, CreateGymDTO>().ReverseMap();
            CreateMap<GymDTO, CreateGymDTO>().ReverseMap();
        }
    }
}
