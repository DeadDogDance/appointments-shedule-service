using DataBase.Models;
using domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Converters
{
    public static class UserModelToDomainConverter
    {
        public static User? ToDomain(this UserModel model)
        {
            return new User(model.UserId, model.Login, model.Password, model.PhoneNumber, model.UserName, (AccountRole) model.UserRole);
        }
    }
}
