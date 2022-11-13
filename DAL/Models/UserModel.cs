using System.ComponentModel.DataAnnotations;
namespace DataBase.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public int UserRole { get; set; }
    }
}
