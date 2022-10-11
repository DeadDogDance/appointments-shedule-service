namespace domain.Entities
{
    public class User
    {
        public int UserId { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string PhoneNumber { get; private set; }
        public string UserName { get; private set; }
        public AccountRole UserRole { get; private set; }

        public User(int userId, string login, string password, string phoneNumber, string userName, AccountRole userRole)
        {
            UserId = userId;
            Login = login;
            Password = password;
            PhoneNumber = phoneNumber;
            UserName = userName;
            UserRole = userRole;
        }
    }
}