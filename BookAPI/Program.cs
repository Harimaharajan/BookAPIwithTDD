using System;

namespace BookAPI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public string ValidateNewBookModel(BookModel bookModel)
        {
            string result = string.Empty;
            return result;
        }

        public bool IsBookAvailable(BookModel bookModel)
        {
            throw new NotImplementedException();
        }

        public string AddNewBook(BookModel bookModel)
        {
            throw new NotImplementedException();
        }
    }
}
