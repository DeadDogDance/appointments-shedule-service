using domain.Entities;

namespace domain.Adaptors
{
    public interface IUserAdaptor
    {
        public bool CheckUser(string login, string password);
        public User? CreateUser(User user);
        public User? GetUserByLogin(string login);
    }
}
