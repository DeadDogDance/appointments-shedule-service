using domain.Entities;

namespace domain.Adaptors
{
    public interface IUserAdaptor
    {
        public bool CheckUser(string login, string password);
        public User? CreateUser(int userId, string login, string password, string phoneNumber, string userName, AccountRole userRole);
        public User? GetUserByLogin(string login);
    }
}
