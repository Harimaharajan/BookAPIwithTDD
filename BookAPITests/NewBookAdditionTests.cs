using System;
using Xunit;
using BookAPI;
using AutoFixture;
using Xunit.Sdk;
using System.ComponentModel.DataAnnotations;

namespace BookAPITests
{
    public class NewBookAdditionTests
    {
        [Fact]
        public void ValidateNewBook_IsBookNameEmptyTest_ReturnsValidationException()
        {
            var expectedException = new ValidationException(Constants.InvalidBookName);
            var actualException = Assert.Throws<ValidationException>(() => BookRepository.Instance.IsValidBookName(string.Empty));

            Assert.Equal(expectedException.Message, actualException.Message);
        }

        [Fact]
        public void ValidateNewBook_IsBookOwnerNameEmptyTest_ReturnsValidationException()
        {
            var expectedException = new ValidationException(Constants.InvalidBookOwnerName);
            var actualException = Assert.Throws<ValidationException>(() => BookRepository.Instance.IsValidBookOwnerName(string.Empty));

            Assert.Equal(expectedException.Message, actualException.Message);
        }

        [Fact]
        public void ValidateNewBook_IsBookOwnerExistsAlreadyTest_ReturnsValidationMessage()
        {
            UserRepository userRepository = new UserRepository();
            userRepository.InitializeUsers();
            var fixture = new Fixture();
            string ownerName = "Mark";

            Assert.True(userRepository.IsBookOwnerExistsAlready(ownerName));
        }

        [Fact]
        public void ValidateNewBook_IsBookOwnerExistsAlreadyTest2_ReturnsValidationException()
        {
            UserRepository userRepository = new UserRepository();
            userRepository.InitializeUsers();
            var fixture = new Fixture();
            string ownerName = "Henry";
            var expectedException = new ValidationException(Constants.BookOwnerNotRegistered);
            var actualException = Assert.Throws<ValidationException>(() => userRepository.IsBookOwnerExistsAlready(ownerName));

            Assert.Equal(expectedException.Message, actualException.Message);
        }

        [Fact]
        public void ValidateNewBook_IsBookAlreadyExistsTest_ReturnsValidationString()
        {
            var fixture = new Fixture();
            BookModel bookModel = fixture.Create<BookModel>();

            Assert.True(BookRepository.Instance.ValidateIfBookAlreadyExists(bookModel));
        }

        [Fact]
        public void ValidateNewBook_BookAdditionSuccessTest_ReturnsSuccessMessage()
        {
            var fixture = new Fixture();
            BookModel bookModel = fixture.Create<BookModel>();
            int expectedID = bookModel.ID;
            Assert.Equal(expectedID, BookRepository.Instance.AddNewBook(bookModel));
        }

        [Fact]
        public void ValidateNewBook_IsValidBookModelTest_ReturnsValidationString()
        {
            BookModel bookModel = null;
            var expectedException = new ValidationException(Constants.InvalidBookDetails);
            var actualException = Assert.Throws<ValidationException>(() => BookRepository.Instance.ValidateNewBookModel(bookModel));

            Assert.Equal(expectedException.Message,actualException.Message);
        }

        [Fact]
        public void ValidateNewBook_IsBookAvailableTest_ReturnsValidationString()
        {
            var fixture = new Fixture();
            bool expectedResult = true;
            BookModel bookModel = fixture.Build<BookModel>().With(x => x.AvailabilityStatus, true).Create();

            Assert.Equal(expectedResult, BookRepository.Instance.IsBookAvailable(bookModel));
        }

        [Fact]
        public void ValidateNewBook_IsBookInAvailableTest_ReturnsValidationString()
        {
            var fixture = new Fixture();
            bool expectedResult = false;
            BookModel bookModel = fixture.Build<BookModel>().With(x => x.AvailabilityStatus, false).Create();

            Assert.Equal(expectedResult, BookRepository.Instance.IsBookAvailable(bookModel));
        }
    }
}
