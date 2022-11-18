using domain.Adaptors;
using domain.Entities;

namespace domain.Interactors
{
    public class UserInteractor
    {
        
        private readonly IUserAdapter _userAdaptor;

        public UserInteractor(IUserAdapter userAdaptor)
        {
            _userAdaptor = userAdaptor;
        }

        public Result CheckUser(string login, string password)
        {
            if (string.IsNullOrEmpty(login))
                return Result.Fail("Empty login");
            if (string.IsNullOrEmpty(password))
                return Result.Fail("Empty password");

            User? user = GetUserByLogin(login).Value;

            if (user is null)
                return Result.Fail("User not found");

            return password == user.Password ? Result.Ok() : Result.Fail("Password don't match");

        }
        public Result<User> CreateUser(int userId, string login, string password, string phoneNumber, string userName, AccountRole userRole)
        {
            if (string.IsNullOrEmpty(login))
                return Result.Fail<User>("Empty login");
            if (string.IsNullOrEmpty(password))
                return Result.Fail<User>("Empty password");
            if (string.IsNullOrEmpty(phoneNumber))
                return Result.Fail<User>("Empty phone number");
            if (string.IsNullOrEmpty(userName))
                return Result.Fail<User>("Empty name");

            User? existed_user = GetUserByLogin(login).Value;

            User user = new User(userId, login, password, phoneNumber, userName, userRole);

            return existed_user is null ? Result.Ok<User>(user) : Result.Fail<User>("Login already taken");
        }
        public Result<User> GetUserByLogin(string login)
        {
            if (string.IsNullOrEmpty(login))
                return Result.Fail<User>("Empty login");

            User? user = _userAdaptor.GetUserByLogin(login);

            return user is null ? Result.Fail<User>("User not found") : Result.Ok(user);
        }


    }
}
