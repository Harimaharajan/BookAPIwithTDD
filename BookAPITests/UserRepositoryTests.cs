using System.ComponentModel.DataAnnotations;
using BookAPI;
using Xunit;

namespace BookAPITests
{
    public class UserRepositoryTests
    {
        [Fact]
        public void ValidateNewBook_IsBookOwnerExistsAlreadyTest_ReturnsTrue()
        {
            UserRepository userRepository = new UserRepository();
            userRepository.InitializeUsers();
            string ownerName = "Mark";

            Assert.True(userRepository.IsBookOwnerExistsAlready(ownerName));
        }

        [Fact]
        public void ValidateNewBook_IsBookOwnerDoesNotExistsTest_ReturnsValidationException()
        {
            UserRepository userRepository = new UserRepository();
            userRepository.InitializeUsers();
            string ownerName = "Henry";
            var expectedException = new ValidationException(Constants.BookOwnerNotRegistered);
            var actualException = Assert.Throws<ValidationException>(() => userRepository.IsBookOwnerExistsAlready(ownerName));

            Assert.Equal(expectedException.Message, actualException.Message);
        }
    }
}
