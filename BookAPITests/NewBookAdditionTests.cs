using System.ComponentModel.DataAnnotations;
using AutoFixture;
using BookAPI;
using Unity;
using Xunit;

namespace BookAPITests
{
    public class NewBookAdditionTests
    {
        IUnityContainer container = new UnityContainer();

        public void Initialize()
        {
            container.RegisterType<IBookRepository, BookRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
        }

        [Fact]
        public void AddNewBook_IsBookNameEmptyTest_ReturnsValidationException()
        {
            Initialize();
            BookRepository bookRepository = container.Resolve<BookRepository>();
            var expectedException = new ValidationException(Constants.InvalidBookName);
            var fixture = new Fixture();
            BookModel bookModel = fixture.Build<BookModel>().With(x => x.BookName, string.Empty).Create();
            var actualException = Assert.Throws<ValidationException>(() => bookRepository.AddNewBook(bookModel));

            Assert.Equal(expectedException.Message, actualException.Message);
        }

        [Fact]
        public void AddNewBook_IsBookOwnerNameEmptyTest_ReturnsValidationException()
        {
            Initialize();
            BookRepository bookRepository = container.Resolve<BookRepository>();
            var expectedException = new ValidationException(Constants.InvalidBookOwnerName);
            var fixture = new Fixture();
            BookModel bookModel = fixture.Build<BookModel>().With(x => x.OwnerName, string.Empty).Create();
            var actualException = Assert.Throws<ValidationException>(() => bookRepository.AddNewBook(bookModel));

            Assert.Equal(expectedException.Message, actualException.Message);
        }

        //[Fact]
        public void AddNewBook_IsBookAlreadyExistsTest_ReturnsTrue()
        {
            Initialize();
            BookRepository bookRepository = container.Resolve<BookRepository>();
            var fixture = new Fixture();
            BookModel bookModel1 = fixture.Build<BookModel>().With(x => x.BookName, "C#").Create();
            bookRepository.AddNewBook(bookModel1);


            BookModel bookModel2 = fixture.Build<BookModel>().With(x => x.BookName, "C#").Create();
            int expectedID = bookModel1.ID;

            Assert.Equal(expectedID, bookRepository.AddNewBook(bookModel2));


            //Initialize();
            //BookRepository bookRepository = container.Resolve<BookRepository>();
            //var fixture = new Fixture();
            //BookModel bookModel = fixture.Create<BookModel>();

            //Assert.True(bookRepository.ValidateIfBookAlreadyExists(bookModel));
        }

        [Fact]
        public void AddNewBook_BookAdditionSuccessTest_ReturnsSuccessMessage()
        {
            Initialize();
            BookRepository bookRepository = container.Resolve<BookRepository>();
            var fixture = new Fixture();
            BookModel bookModel = fixture.Build<BookModel>().With(x => x.OwnerName, "Mark").Create();
            int expectedID = bookModel.ID;

            Assert.Equal(expectedID, bookRepository.AddNewBook(bookModel));
        }

        [Fact]
        public void AddNewBook_IsValidBookModelTest_ReturnsValidationString()
        {
            Initialize();
            BookRepository bookRepository = container.Resolve<BookRepository>();
            BookModel bookModel = null;
            var expectedException = new ValidationException(Constants.InvalidBookDetails);
            var actualException = Assert.Throws<ValidationException>(() => bookRepository.AddNewBook(bookModel));

            Assert.Equal(expectedException.Message,actualException.Message);
        }

        [Fact]
        public void AddNewBook_IsBookAvailableTest_ReturnsValidationString()
        {
            Initialize();
            BookRepository bookRepository = container.Resolve<BookRepository>();
            var fixture = new Fixture();
            bool expectedResult = true;
            BookModel bookModel = fixture.Build<BookModel>().With(x => x.AvailabilityStatus, true).Create();

            Assert.Equal(expectedResult, bookRepository.IsBookAvailable(bookModel));
        }

        [Fact]
        public void AddNewBook_IsBookInAvailableTest_ReturnsValidationString()
        {
            Initialize();
            BookRepository bookRepository = container.Resolve<BookRepository>();
            var fixture = new Fixture();
            bool expectedResult = false;
            BookModel bookModel = fixture.Build<BookModel>().With(x => x.AvailabilityStatus, false).Create();

            Assert.Equal(expectedResult, bookRepository.IsBookAvailable(bookModel));
        }
    }
}
