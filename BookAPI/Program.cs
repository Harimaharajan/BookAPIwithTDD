using System;

namespace BookAPI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Book Exchange");
            BookModel newBook = new BookModel();
            UserRepository userRepository = new UserRepository();
            string bookName, bookOwner;
            bool bookAvailability = false;

            Console.WriteLine("Please Enter Book name");
            bookName = Console.ReadLine();
            BookRepository.Instance.IsValidBookName(bookName);
            Console.WriteLine("Please Enter Book Owner name");
            bookOwner = Console.ReadLine();
            BookRepository.Instance.IsValidBookOwnerName(bookOwner);
            userRepository.IsBookOwnerExistsAlready(bookOwner);
            newBook.BookName = bookName;
            newBook.OwnerName = bookOwner;
            newBook.AvailabilityStatus = bookAvailability;
            int result = BookRepository.Instance.AddNewBook(newBook);
            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
