using DataBase.Models;
using domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Converters
{
    public static class DoctorModelToDomainConverter
    {
        public static Doctor? ToDomain(this DoctorModel model)
        {
            return new Doctor(model.DoctorId, model.DoctorName, model.SpecializationId);
        }
    }
}
