using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookAPI
{
    public class Program
    {
        static BookRepository bookRepository = new BookRepository();
        public static List<BookModel> bookList = new List<BookModel>();

        static void Main(string[] args)
        {
            Console.WriteLine("Book Exchange");
            BookModel newBook = new BookModel();
            string bookName, bookOwner;
            bool bookAvailability = false;
            Console.WriteLine("Please Enter Book name");
            bookName = Console.ReadLine();
            ValidateBookName(bookName);
            Console.WriteLine("Please Enter Book Owner name");
            bookOwner = Console.ReadLine();            
           
            newBook.BookName = bookName;
            newBook.OwnerName = bookOwner;
            newBook.AvailabilityStatus = bookAvailability;
            bool result = AddNewBook(newBook);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static bool ValidateBookName(string bookName)
        {
            if (string.IsNullOrEmpty(bookName))
            {
                throw new ValidationException(Constants.InvalidBookName);
            }
            return true;
        }

        public static bool ValidateBookOwnerName(string bookOwnerName)
        {
            if (string.IsNullOrEmpty(bookOwnerName))
            {
                throw new ValidationException(Constants.InvalidBookOwnerName);
            }
            return true;
        }

        public static bool ValidateIfBookAlreadyExists(BookModel bookModel)
        {
            foreach (BookModel book in bookList)
            {
                if (book.BookName == bookModel.BookName)
                {
                    throw new ValidationException(Constants.InvalidBookAlreadyExists);
                }
            }
            return true;
        }

        public static bool ValidateNewBookModel(BookModel bookModel)
        {
            if (bookModel == null)
            {
                throw new ValidationException(Constants.InvalidBookDetails);
            }
            else if(string.IsNullOrEmpty(bookModel.BookName))
            {
                throw new ValidationException(Constants.InvalidBookName);
            }
            else if(string.IsNullOrEmpty(bookModel.OwnerName))
            {
                throw new ValidationException(Constants.InvalidBookOwnerName);
            }
            else
            {
                foreach(BookModel book in bookList)
                {
                    if(book.BookName==bookModel.BookName)
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

        public static bool AddNewBook(BookModel bookModel)
        {
            if(ValidateNewBookModel(bookModel))
            {
                bookModel.ID = bookList.Count + 1;

                bookRepository.BookList.Add(bookModel);
                return true;
            }

            return false;
        }
    }
}
