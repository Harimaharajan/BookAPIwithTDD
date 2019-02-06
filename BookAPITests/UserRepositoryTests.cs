using System.ComponentModel.DataAnnotations;
using BookAPI;
using Unity;
using Xunit;

namespace BookAPITests
{
    public class UserRepositoryTests
    {
        private static IUnityContainer Initialize()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IUserRepository, UserRepository>();
            return container;
        }

        [Fact]
        public void ValidateBookOwner_IfBookOwnerDoesNotExistsTest_ReturnsValidationException()
        {
            var container = Initialize();
            var userRepository = container.Resolve<UserRepository>();
            var ownerName = "Henry";
            var expectedException = new ValidationException(Constants.BookOwnerNotRegistered);
            var actualException =
                Assert.Throws<ValidationException>(() => userRepository.IsBookOwnerExistsAlready(ownerName));

            Assert.Equal(expectedException.Message, actualException.Message);
        }

        [Fact]
        public void ValidateBookOwner_IsBookOwnerExistsAlready_ReturnsTrue()
        {
            var container = Initialize();
            var userRepository = container.Resolve<UserRepository>();
            var ownerName = "Mark";

            Assert.True(userRepository.IsBookOwnerExistsAlready(ownerName));
        }
    }
}