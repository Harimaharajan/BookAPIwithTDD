using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookAPI
{
    public class BookRepository
    {
        private List<BookModel> _booklist = new List<BookModel>();

        public List<BookModel> BookList
        {
            get
            {
                return this._booklist;
            }
            set
            {
                this._booklist = value;
            }
        }

        public bool ValidateBookName(string bookName)
        {
            if (string.IsNullOrEmpty(bookName))
            {
                throw new ValidationException(Constants.InvalidBookName);
            }
            return true;
        }

        public bool ValidateBookOwnerName(string bookOwnerName)
        {
            if (string.IsNullOrEmpty(bookOwnerName))
            {
                throw new ValidationException(Constants.InvalidBookOwnerName);
            }
            return true;
        }

        public bool ValidateIfBookAlreadyExists(BookModel bookModel)
        {
            foreach (BookModel book in BookList)
            {
                if (book.BookName == bookModel.BookName)
                {
                    throw new ValidationException(Constants.InvalidBookAlreadyExists);
                }
            }
            return true;
        }

        public bool ValidateNewBookModel(BookModel bookModel)
        {
            if (bookModel == null)
            {
                throw new ValidationException(Constants.InvalidBookDetails);
            }
            else if (string.IsNullOrEmpty(bookModel.BookName))
            {
                throw new ValidationException(Constants.InvalidBookName);
            }
            else if (string.IsNullOrEmpty(bookModel.OwnerName))
            {
                throw new ValidationException(Constants.InvalidBookOwnerName);
            }
            else
            {
                foreach (BookModel book in BookList)
                {
                    if (book.BookName == bookModel.BookName)
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

        public bool AddNewBook(BookModel bookModel)
        {
            if (ValidateNewBookModel(bookModel))
            {
                bookModel.ID = BookList.Count + 1;

                BookList.Add(bookModel);
                return true;
            }

            return false;
        }
    }
}
