using LegacyApp;

namespace LegacyAppTests
{
    public class UserServiceTests
    {

        [Test]
        public void AddUser_Should_Return_False_When_Missing_FirstName()
        {
            //Arrange
            var service = new UserService();
            //Act
            var result = service.AddUser(null, null, "kowalski@wp.pl", new DateTime(1980, 1, 1), 1);
            //Assert
            Assert.False(result);

        }


        public void AddUser_Should_Throw_Exception_When_User_Does_Not_Exist()
        {
            //Arrange
            var service = new UserService();
            //Act
            var result = service.AddUser(null, null, "kowalski@wp.pl", new DateTime(1980, 1, 1), 1);
            //Assert
            Assert.False(result);

        }
    }
}