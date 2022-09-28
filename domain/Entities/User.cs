namespace domain.Entities
{
    public class User
    {
        public int UserId { get; private set; }
        public string PhoneNumber { get; private set; }
        public string UserName { get; private set; }
        public AccountRole UserRole { get; private set; }

    }
}