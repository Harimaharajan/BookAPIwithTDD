using System;
using System.Collections.Generic;
using System.Text;

namespace BookAPI
{
    public class BookModel
    {
        public int ID
        {
            get;
            set;
        }

        public string BookName
        {
            get;
            set;
        }

        public string OwnerName
        {
            get;
            set;
        }

        public bool AvailabilityStatus
        {
            get;
            set;
        }
    }
}
