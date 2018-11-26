using System;
using Xunit;
using BookAPI;
using AutoFixture;

namespace BookAPITests
{
    public class NewBookAdditionTests
    {
        [Fact]
        public void ValidateNewBook_BookNameEmptyTest_ReturnsValidationString()
        {
            string bookName = string.Empty;
            string expectedResult = "Book Name cannot be Empty";

            Assert.Equal(expectedResult, Program.ValidateBookName(bookName));
        }

        [Fact]
        public void ValidateNewBook_BookOwnerNameEmptyTest_ReturnsValidationString()
        {
            string bookOwnerName = string.Empty;
            string expectedResult = "Book Owner Name cannot be Empty";

            Assert.Equal(expectedResult, Program.ValidateBookOwnerName(bookOwnerName));
        }

        [Fact]
        public void ValidateNewBook_BookAlreadyExistsTest_ReturnsValidationString()
        {
            var fixture = new Fixture();
            BookModel bookModel = fixture.Create<BookModel>();

            Assert.Equal("Book Already Exists", Program.ValidateNewBookModel(bookModel));
        }

        [Fact]
        public void ValidateNewBook_BookAdditionSuccessTest_ReturnsSuccessMessage()
        {
            var fixture = new Fixture();
            BookModel bookModel = fixture.Create<BookModel>();

            Assert.Equal("Book Addition Successful", Program.AddNewBook(bookModel));
        }

        [Fact]
        public void ValidateNewBook_BookModelTest_ReturnsValidationString()
        {
            BookModel bookModel = null;
            string expectedResult = "Book Details cannot be Empty";

            Assert.Equal(expectedResult, Program.ValidateNewBookModel(bookModel));
        }

        [Fact]
        public void ValidateNewBook_BookAvailabilityTest_ReturnsValidationString()
        {
            Program p = new Program();
            var fixture = new Fixture();
            BookModel bookModel = fixture.Create<BookModel>();

            Assert.True(p.IsBookAvailable(bookModel));
        }

        [Fact]
        public void ValidateNewBook_BookInAvailabilityTest_ReturnsValidationString()
        {
            Program p = new Program();
            var fixture = new Fixture();
            BookModel bookModel = fixture.Create<BookModel>();

            Assert.False(p.IsBookAvailable(bookModel));
        }
    }
}
