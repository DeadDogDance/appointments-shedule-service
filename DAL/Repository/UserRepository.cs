using DataBase.Converters;
using DataBase.Models;
using domain.Adaptors;
using domain.Entities;

namespace DataBase.Repository
{
    public class UserRepository : IUserAdapter
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool CheckUser(string login, string password)
        {
            var user = _context.Users.FirstOrDefault(user => (user.Login == login && user.Password == password));

            return user is not null ? true : false;   
        }

        public User? CreateUser(int userId, string login, string password, string phoneNumber, string userName, AccountRole userRole)
        {
            var user = new UserModel {
                UserId = userId,
                Login = login,
                Password = password,
                PhoneNumber = phoneNumber,
                UserName = userName,
                UserRole =  userRole
            };


            _context.Users.Add(user);
            _context.SaveChanges();


            return user.ToDomain();
        }

        public User? GetUserByLogin(string login)
        {
            var user = _context.Users.FirstOrDefault(user => user.Login == login);
            return user?.ToDomain();
        }
    }
}
