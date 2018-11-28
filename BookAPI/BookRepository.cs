using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BookAPI
{
    public sealed class BookRepository : IBookRepository
    {
        private IUserRepository UserRepository;

        public BookRepository(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        private List<BookModel> _booklist = new List<BookModel>();

        public List<BookModel> BookList
        {
            get
            {
                return _booklist;
            }
            set
            {
                _booklist = value;
            }
        }

        private bool ValidateNewBookModel(BookModel bookModel)
        {
            if (bookModel == null)
            {
                throw new ValidationException(Constants.InvalidBookDetails);
            }
            if (string.IsNullOrEmpty(bookModel.BookName))
            {
                throw new ValidationException(Constants.InvalidBookName);
            }
            if (string.IsNullOrEmpty(bookModel.OwnerName))
            {
                throw new ValidationException(Constants.InvalidBookOwnerName);
            }
            if(!UserRepository.IsBookOwnerExistsAlready(bookModel.OwnerName))
            {
                throw new ValidationException(Constants.BookOwnerNotRegistered);
            }
            else
            {
                if (BookList.Count > 0)
                {
                    var bookAlreadyExists = BookList.Where(n => n.BookName == bookModel.BookName);

                    if (bookAlreadyExists != null)
                    {
                        throw new ValidationException(Constants.InvalidBookAlreadyExists);
                    }
                }
            }

            return true;
        }

        public bool IsBookAvailable(BookModel bookModel)
        {
            return bookModel.AvailabilityStatus;
        }

        public int AddNewBook(BookModel bookModel)
        {
            if (ValidateNewBookModel(bookModel))
            {
                if (bookModel.ID == 0)
                {
                    bookModel.ID = BookList.Count + 1;
                }
                
                BookList.Add(bookModel);
                return bookModel.ID;
            }

            return 0;
        }
    }
}
