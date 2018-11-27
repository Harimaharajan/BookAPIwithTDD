namespace BookAPI
{
    public class Users
    {
        private int _id;
        private string _ownerName;

        public Users(int id, string userName)
        {
            _id = id;
            _ownerName = userName;
        }

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string OwnerName
        {
            get
            {
                return _ownerName;
            }
            set
            {
                _ownerName = value;
            }
        }
    }
}
