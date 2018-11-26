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
            var expectedException = new ValidationException(Constants.InvalidBookName);
            var actualException = Assert.Throws<ValidationException>(() => Program.ValidateBookName(string.Empty));

            Assert.Equal(expectedException.Message, actualException.Message);
        }

        [Fact]
        public void ValidateNewBook_BookOwnerNameEmptyTest_ReturnsValidationString()
        {
            var expectedException = new ValidationException(Constants.InvalidBookOwnerName);
            var actualException = Assert.Throws<ValidationException>(() => Program.ValidateBookOwnerName(string.Empty));

            Assert.Equal(expectedException.Message, actualException.Message);
        }

        [Fact]
        public void ValidateNewBook_BookAlreadyExistsTest_ReturnsValidationString()
        {
            var fixture = new Fixture();
            BookModel bookModel = fixture.Create<BookModel>();

            Assert.True(Program.ValidateIfBookAlreadyExists(bookModel));
        }

        [Fact]
        public void ValidateNewBook_BookAdditionSuccessTest_ReturnsSuccessMessage()
        {
            var fixture = new Fixture();
            BookModel bookModel = fixture.Create<BookModel>();

            Assert.True(Program.AddNewBook(bookModel));
        }

        [Fact]
        public void ValidateNewBook_BookModelTest_ReturnsValidationString()
        {
            BookModel bookModel = null;
            var expectedException = new ValidationException(Constants.InvalidBookDetails);
            var actualException = Assert.Throws<ValidationException>(() => Program.ValidateNewBookModel(bookModel));

            Assert.Equal(expectedException.Message,actualException.Message);
        }

        [Fact]
        public void ValidateNewBook_BookAvailabilityTest_ReturnsValidationString()
        {
            Program p = new Program();
            var fixture = new Fixture();
            bool expectedResult = true;
            BookModel bookModel = fixture.Build<BookModel>().With(x => x.AvailabilityStatus, true).Create();

            Assert.Equal(expectedResult, p.IsBookAvailable(bookModel));
        }

        [Fact]
        public void ValidateNewBook_BookInAvailabilityTest_ReturnsValidationString()
        {
            Program p = new Program();
            var fixture = new Fixture();
            bool expectedResult = false;
            BookModel bookModel = fixture.Build<BookModel>().With(x => x.AvailabilityStatus, false).Create();

            Assert.Equal(expectedResult,p.IsBookAvailable(bookModel));
        }
    }
}
