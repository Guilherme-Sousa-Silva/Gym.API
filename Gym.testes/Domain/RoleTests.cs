using Gym.Domain.Entities;
using Gym.Domain.Enumerables;

namespace Gym.testes.Domain
{
    public class RoleTests
    {
        [Fact]
        public void Create_Role_With_Success()
        {
            //Arrange
            var name = "teste";
            var type = ERoleType.Representante;

            //Act
            var role = new Role(name, type);

            // Assert
            Assert.Equal(role.Name, name);
            Assert.Equal(role.RoleType, type);
        }

        [Fact]
        public void Create_Role_With_Name_Null_Should_Return_Error()
        {
            //Arrange
            var name = "";
            var type = ERoleType.Representante;

            //Act
            var role = new Role(name, type);

            // Assert
            Assert.Equal(role.Name, name);
            Assert.Equal(role.RoleType, type);
        }
    }
}
