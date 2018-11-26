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
            bookRepository.ValidateBookName(bookName);
            Console.WriteLine("Please Enter Book Owner name");
            bookOwner = Console.ReadLine();
            bookRepository.ValidateBookOwnerName(bookOwner);
            newBook.BookName = bookName;
            newBook.OwnerName = bookOwner;
            newBook.AvailabilityStatus = bookAvailability;
            bool result = bookRepository.AddNewBook(newBook);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
