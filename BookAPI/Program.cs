using System;
using Unity;

namespace BookAPI
{
    public class Program
    {
        static void Main(string[] args)
        {
            IUserRepository userRepository = new UserRepository();

            IUnityContainer container = new UnityContainer();
            container.RegisterSingleton<BookRepository>();
            container.RegisterType<IUserRepository, UserRepository>();

            BookRepository bookRepository = container.Resolve<BookRepository>();

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
            //int result = BookRepository.Instance.AddNewBook(newBook);
            int result = bookRepository.AddNewBook(newBook);
            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
