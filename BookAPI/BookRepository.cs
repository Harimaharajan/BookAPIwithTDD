using System;
using System.Collections.Generic;
using System.Text;

namespace BookAPI
{
    public class BookRepository
    {
        private List<BookModel> _booklist = new List<BookModel>();

        public List<BookModel> BookList
        {
            get
            {
                return this._booklist;
            }
            set
            {
                this._booklist = value;
            }
        }


    }
}
