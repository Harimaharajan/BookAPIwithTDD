using System;
using System.Collections.Generic;

namespace BookAPI
{
    public class Program
    {
        public static List<BookModel> bookList = new List<BookModel>();

        static void Main(string[] args)
        {
            Console.WriteLine("Book Exchange");
            BookModel newBook = new BookModel();
            string bookName, bookOwner;
            bool bookAvailability = false;
            do
            {
                Console.WriteLine("Please Enter Book name");
                bookName = Console.ReadLine();
            } while (ValidateBookName(bookName) == "Book Name cannot be Empty");

            do
            {
                Console.WriteLine("Please Enter Book Owner name");
                bookOwner = Console.ReadLine();
            } while (ValidateBookOwnerName(bookOwner) == "Book Owner Name cannot be Empty");
           
            newBook.BookName = bookName;
            newBook.OwnerName = bookOwner;
            newBook.AvailabilityStatus = bookAvailability;
            string result = AddNewBook(newBook);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static string ValidateBookName(string bookName)
        {
            string result = string.Empty;
            if (string.IsNullOrEmpty(bookName))
            {
                result = "Book Name cannot be Empty";
            }
            return result;
        }

        public static string ValidateBookOwnerName(string bookOwnerName)
        {
            string result = string.Empty;
            if (string.IsNullOrEmpty(bookOwnerName))
            {
                result = "Book Owner Name cannot be Empty";
            }
            return result;
        }

        public static string ValidateNewBookModel(BookModel bookModel)
        {
            string result = string.Empty;
            if (bookModel == null)
            {
                return "Book Details cannot be Empty";
            }
            else if(string.IsNullOrEmpty(bookModel.BookName))
            {
                return "Book Name cannot be Empty";
            }
            else if(string.IsNullOrEmpty(bookModel.OwnerName))
            {
                return "Book Owner Name cannot be Empty";
            }
            else
            {
                foreach(BookModel book in bookList)
                {
                    if(book.BookName==bookModel.BookName)
                    {
                        return "Book Already Exists";
                    }
                }
            }
            result = "Book validation Successful";

            return result;
        }

        public bool IsBookAvailable(BookModel bookModel)
        {
            throw new NotImplementedException();
        }

        public static string AddNewBook(BookModel bookModel)
        {
            if(ValidateNewBookModel(bookModel)== "Book validation Successful")
            {
                bookModel.ID = bookList.Count + 1;
                bookList.Add(bookModel);
            }

            return "Book Addition Successful";
        }
    }
}
