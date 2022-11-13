using DataBase.Models;
using domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Converters
{
    public static class AppointmentModelToDomainConverter
    {
        public static Appointment? ToDomain(this AppointmentModel model)
        {
            return new Appointment(model.StartTime, model.EndTime, model.UserId, model.DoctorId);
        }
    }
}
