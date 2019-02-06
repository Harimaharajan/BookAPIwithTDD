using System;
using System.Data.SqlClient;
using Unity;

namespace BookAPI
{
    public class Program
    {
        private static void Main(string[] args)
        {
            SqlConnection connection=new SqlConnection();
            
            IUnityContainer container = new UnityContainer();
            container.RegisterSingleton<IBookRepository, BookRepository>();
            container.RegisterType<IUserRepository, UserRepository>();

            var bookRepository = container.Resolve<BookRepository>();

            var newBook = GetInputBookModel(out var bookAvailability, out var bookName, out var bookOwner);

            newBook.BookName = bookName;
            newBook.OwnerName = bookOwner;
            newBook.AvailabilityStatus = bookAvailability;

            var result = bookRepository.AddNewBook(newBook);
            Console.WriteLine(result);

            Console.ReadKey();
        }

        private static BookModel GetInputBookModel(out bool bookAvailability, out string bookName, out string bookOwner)
        {
            Console.WriteLine("Book Exchange");
            Console.WriteLine("Book Exchange");
            var newBook = new BookModel();
            bookAvailability = false;

            Console.WriteLine("Please Enter Book name");
            bookName = Console.ReadLine();

            Console.WriteLine("Please Enter Book Owner name");
            bookOwner = Console.ReadLine();
            return newBook;
        }
    }
}