using System;
using System.Collections.Generic;
using System.Text;

namespace BookAPI
{
    public interface IBookRepository
    {
        bool IsBookAvailable(BookModel bookModel);
        int AddNewBook(BookModel bookModel);
    }
}
