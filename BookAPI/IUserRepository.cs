using System;
using System.Collections.Generic;
using System.Text;

namespace BookAPI
{
    public interface IUserRepository
    {
        bool IsBookOwnerExistsAlready(string ownerName);
    }
}
