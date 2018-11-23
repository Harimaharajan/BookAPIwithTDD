using System;
using Xunit;
using BookAPI;

namespace BookAPITests
{
    public class NewBookAdditionTests
    {
        Program p = new Program();
        public BookModel InitializeBookModel()
        {
            BookModel bookModel = new BookModel();
            bookModel.ID = 1;
            bookModel.BookName = "C# Programming";
            bookModel.OwnerName = "Mark";
            bookModel.AvailabilityStatus = true;
            return bookModel;
        }

        [Fact]
        public void BookNameEmptyTest()
        {
            BookModel bookModel = InitializeBookModel();
            bookModel.BookName = string.Empty;
            Assert.Equal("Book Name cannot Empty", p.ValidateNewBookModel(bookModel));
        }

        [Fact]
        public void BookOwnerNameEmptyTest()
        {
            BookModel bookModel = InitializeBookModel();
            bookModel.OwnerName = string.Empty;
            Assert.Equal("Book Owner Name cannot Empty", p.ValidateNewBookModel(bookModel));
        }

        [Fact]
        public void BookAlreadyExistsTest()
        {
            BookModel bookModel = InitializeBookModel();
            bookModel.BookName = string.Empty;
            Assert.Equal("Book Already Exists", p.ValidateNewBookModel(bookModel));
        }

        [Fact]
        public void BookAdditionSuccessTest()
        {
            BookModel bookModel = InitializeBookModel();
            Assert.Equal("Book Addition Successful", p.AddNewBook(bookModel));
        }

        [Fact]
        public void BookModelTest()
        {
            BookModel bookModel = null;
            Assert.Equal("Book Details cannot be Empty", p.ValidateNewBookModel(bookModel));
        }

        [Fact]
        public void BookAvailabilityTest()
        {
            BookModel bookModel = InitializeBookModel();
            Assert.True(p.IsBookAvailable(bookModel));
        }

        [Fact]
        public void BookInAvailabilityTest()
        {
            BookModel bookModel = InitializeBookModel();
            Assert.False(p.IsBookAvailable(bookModel));
        }
    }
}
