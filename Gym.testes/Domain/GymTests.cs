using Gym.Domain.Entities;

namespace Gym.testes.Domain
{
    public class GymTests
    {
        [Fact]
        public void Create_Gym_Return_Success()
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
        public void Create_Gym_With_Cnpj_Null_Should_Return_Error()
        {
            // Arrange
            var cnpj = "";
            var razaoSocail = "Teste";
            var nomeFantasia = "Nome Fantasia Teste";

            // Act
            var gym = new Gym.Domain.Entities.Gym(cnpj, razaoSocail, nomeFantasia);
            var validate = gym.Validate(gym);

            // Assert
            Assert.False(validate);
        }

        [Fact]
        public void Create_Gym_With_RazaoSocial_Null_Should_Return_Error()
        {
            // Arrange
            var cnpj = "2154561525";
            var razaoSocail = "";
            var nomeFantasia = "Nome Fantasia Teste";

            // Act
            var gym = new Gym.Domain.Entities.Gym(cnpj, razaoSocail, nomeFantasia);
            var validate = gym.Validate(gym);

            // Assert
            Assert.False(validate);
        }

        [Fact]
        public void Create_Gym_With_NomeFantasia_Null_Should_Return_Error()
        {
            // Arrange
            var cnpj = "2154561525";
            var razaoSocail = "teste";
            var nomeFantasia = "";

            // Act
            var gym = new Gym.Domain.Entities.Gym(cnpj, razaoSocail, nomeFantasia);
            var validate = gym.Validate(gym);

            // Assert
            Assert.False(validate);
        }
    }
}
