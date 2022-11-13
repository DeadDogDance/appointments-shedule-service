using DataBase.Models;
using domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Converters
{
    public static class ScheduleModelToDomainConverter
    {
        public static Schedule? ToDomain(this ScheduleModel model)
        {
            return new Schedule(model.DoctorId, model.Start, model.End);
        }
    }
}
