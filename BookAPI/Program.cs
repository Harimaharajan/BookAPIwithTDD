using System;

namespace BookAPI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Book Exchange");
            BookModel newBook = new BookModel();
            string bookName, bookOwner;
            bool bookAvailability = false;

            Console.WriteLine("Please Enter Book name");
            bookName = Console.ReadLine();
            
            Console.WriteLine("Please Enter Book Owner name");
            bookOwner = Console.ReadLine();

            newBook.BookName = bookName;
            newBook.OwnerName = bookOwner;
            newBook.AvailabilityStatus = bookAvailability;
            int result = BookRepository.Instance.AddNewBook(newBook);
            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
