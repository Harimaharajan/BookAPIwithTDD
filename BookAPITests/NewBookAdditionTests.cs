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
        public void ValidateNewBook_BookNameEmptyTest_ReturnsValidationString()
        {
            BookRepository bookRepositoryObject = new BookRepository();
            var expectedException = new ValidationException(Constants.InvalidBookName);
            var actualException = Assert.Throws<ValidationException>(() => bookRepositoryObject.ValidateBookName(string.Empty));

            Assert.Equal(expectedException.Message, actualException.Message);
        }

        [Fact]
        public void ValidateNewBook_BookOwnerNameEmptyTest_ReturnsValidationString()
        {
            BookRepository bookRepositoryObject = new BookRepository();
            var expectedException = new ValidationException(Constants.InvalidBookOwnerName);
            var actualException = Assert.Throws<ValidationException>(() => bookRepositoryObject.ValidateBookOwnerName(string.Empty));

            Assert.Equal(expectedException.Message, actualException.Message);
        }

        [Fact]
        public void ValidateNewBook_BookAlreadyExistsTest_ReturnsValidationString()
        {
            BookRepository bookRepositoryObject = new BookRepository();
            var fixture = new Fixture();
            BookModel bookModel = fixture.Create<BookModel>();

            Assert.True(bookRepositoryObject.ValidateIfBookAlreadyExists(bookModel));
        }

        [Fact]
        public void ValidateNewBook_BookAdditionSuccessTest_ReturnsSuccessMessage()
        {
            BookRepository bookRepositoryObject = new BookRepository();
            var fixture = new Fixture();
            BookModel bookModel = fixture.Create<BookModel>();

            Assert.True(bookRepositoryObject.AddNewBook(bookModel));
        }

        [Fact]
        public void ValidateNewBook_BookModelTest_ReturnsValidationString()
        {
            BookRepository bookRepositoryObject = new BookRepository();
            BookModel bookModel = null;
            var expectedException = new ValidationException(Constants.InvalidBookDetails);
            var actualException = Assert.Throws<ValidationException>(() => bookRepositoryObject.ValidateNewBookModel(bookModel));

            Assert.Equal(expectedException.Message,actualException.Message);
        }

        [Fact]
        public void ValidateNewBook_BookAvailabilityTest_ReturnsValidationString()
        {
            BookRepository bookRepositoryObject = new BookRepository();
            var fixture = new Fixture();
            bool expectedResult = true;
            BookModel bookModel = fixture.Build<BookModel>().With(x => x.AvailabilityStatus, true).Create();

            Assert.Equal(expectedResult, bookRepositoryObject.IsBookAvailable(bookModel));
        }

        [Fact]
        public void ValidateNewBook_BookInAvailabilityTest_ReturnsValidationString()
        {
            BookRepository bookRepositoryObject = new BookRepository();
            var fixture = new Fixture();
            bool expectedResult = false;
            BookModel bookModel = fixture.Build<BookModel>().With(x => x.AvailabilityStatus, false).Create();

            Assert.Equal(expectedResult, bookRepositoryObject.IsBookAvailable(bookModel));
        }
    }
}
