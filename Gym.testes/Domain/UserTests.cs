using Gym.Domain.Entities;

namespace Gym.testes.Domain
{
    public class UserTests
    {
        [Fact]
        public void Create_User_With_Success()
        {
            //Arrange
            var name = "Nome teste";
            var email = "teste@gmail.com";

            //Act
            var user = new User(name, email);

            //Assert
            Assert.Equal(user.Name, name);
            Assert.Equal(user.Email, email);
        }

        [Fact]
        public void Create_User_With_Null_Name_Should_Return_Error()
        {
            //Arrange
            var name = "";
            var email = "teste@gmail.com";

            //Act
            var user = new User(name, email);
            var validate = user.Validate(user);

            //Assert
            Assert.False(validate);
        }

        [Fact]
        public void Create_User_With_Null_Email_Should_Return_Error()
        {
            //Arrange
            var name = "Nome teste";
            var email = "";

            //Act
            var user = new User(name, email);
            var validate = user.Validate(user);

            //Assert
            Assert.False(validate);
        }
    }
}
