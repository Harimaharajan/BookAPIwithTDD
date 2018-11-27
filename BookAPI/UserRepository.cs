using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BookAPI
{
    public class UserRepository
    {
        private List<Users> _userList=new List<Users>();

        public List<Users> Users
        {
            get
            {
                return _userList;
            }
            set
            {
                _userList = value;
            }
        }

        public UserRepository()
        {
            Users user1 = new Users(1, "Mark");
            Users user2 = new Users(2, "John");
            Users user3 = new Users(3, "Emma");
            Users.Add(user1);
            Users.Add(user2);
            Users.Add(user3);
        }
        
        public bool IsBookOwnerExistsAlready(string ownerName)
        {
            //var userName = from usersList in Users
            //        where usersList.OwnerName == ownerName
            //        select usersList.OwnerName.ToString();
            var user = Users.Where(p => p.OwnerName == ownerName).ToList();

            if (user.Count > 0)
            {
                return true;
            }
            else
            {
                throw new ValidationException(Constants.BookOwnerNotRegistered);
            }
        }
    }
}
