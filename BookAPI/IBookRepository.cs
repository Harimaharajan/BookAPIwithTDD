using System;
using System.Collections.Generic;
using System.Text;

namespace BookAPI
{
    public interface IBookRepository
    {
        //bool IsValidBookName(string bookName);
        //bool IsValidBookOwnerName(string bookOwnerName);
        //bool ValidateIfBookAlreadyExists(BookModel bookModel);
        //bool ValidateNewBookModel(BookModel bookModel);
        bool IsBookAvailable(BookModel bookModel);
        int AddNewBook(BookModel bookModel);
    }
}
