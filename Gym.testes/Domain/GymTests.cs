using Gym.Domain.Entities;

namespace Gym.testes.Domain
{
    public class GymTests
    {
        [Fact]
        public void CreateGymSuccess()
        {
            // Arrange
            var cnpj = "24123123123";
            var razaoSocail = "Teste";
            var nomeFantasia = "Nome Fantasia Teste";

            // Act
            var gym = new Gym.Domain.Entities.Gym(cnpj, razaoSocail, nomeFantasia);

            // Assert
            Assert.Equal(gym.Cnpj, cnpj);
            Assert.Equal(gym.RazaoSocial, razaoSocail);
            Assert.Equal(gym.NomeFantasia, nomeFantasia);
        }

        [Fact]
        public void CreateGymWithCnpjNullShouldReturnError()
        {
            // Arrange
            var cnpj = "";
            var razaoSocail = "Teste";
            var nomeFantasia = "Nome Fantasia Teste";

            // Act
            var gym = new Gym.Domain.Entities.Gym(cnpj, razaoSocail, nomeFantasia);
            var validate = gym.Validate(gym);

            // Assert
            Assert.Equal(validate, false);
            Assert.False(validate);
        }
    }
}
