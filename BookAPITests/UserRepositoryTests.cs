using System.ComponentModel.DataAnnotations;
using BookAPI;
using Xunit;

namespace BookAPITests
{
    public class UserRepositoryTests
    {
        [Fact]
        public void ValidateBookOwner_IsBookOwnerExistsAlready_ReturnsTrue()
        {
            UserRepository userRepository = new UserRepository();
            string ownerName = "Mark";

            Assert.True(userRepository.IsBookOwnerExistsAlready(ownerName));
        }

        [Fact]
        public void ValidateBookOwner_IfBookOwnerDoesNotExistsTest_ReturnsValidationException()
        {
            UserRepository userRepository = new UserRepository();
            string ownerName = "Henry";
            var expectedException = new ValidationException(Constants.BookOwnerNotRegistered);
            var actualException = Assert.Throws<ValidationException>(() => userRepository.IsBookOwnerExistsAlready(ownerName));

            Assert.Equal(expectedException.Message, actualException.Message);
        }
    }
}
