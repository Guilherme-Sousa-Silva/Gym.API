using AutoMapper;
using Gym.Application.DTOs.Gym;
using Gym.Application.Interfaces;
using Gym.Application.Services;
using Gym.Domain.Interfaces;
using Gym.Infra.Data.Repositories;
using Moq;

namespace Gym.testes.Repository
{
    public class GymServiceTests
    {

        private readonly Mock<IGymService> _service;
        private readonly Mock<IGymRepository> _repository;
        private readonly Mock<IMapper> _mapper;

        public GymServiceTests()
        {
            _service = new Mock<IGymService>();
            _repository = new Mock<IGymRepository>();
            _mapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task Get_All_Gyms()
        {
            //Arrange
            var gyms = new List<Gym.Domain.Entities.Gym>
            {
                new Gym.Domain.Entities.Gym("cnpjA", "socialA", "nomeA"),
                new Gym.Domain.Entities.Gym("cnpjB", "socialB", "nomeB"),
            };

            _repository.Setup(x => x.GetAllAsync()).ReturnsAsync(gyms);
            var gymService = new GymService(_repository.Object, _mapper.Object);
            var gymsDto = gyms.Select(g => new GymDTO(g.Id, g.Cnpj, g.RazaoSocial, g.NomeFantasia)).ToList();

            //Act
            var result = await gymService.GetAllAsync();
            result.Data = gymsDto;

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.Data.Count);
            Assert.Contains(result.Data, g => g.Cnpj == "cnpjA");
            Assert.Contains(result.Data, g => g.Cnpj == "cnpjB");
        }
    }
}
