using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Models
{
    [Keyless]
    public class ScheduleModel
    {
        public int DoctorId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
