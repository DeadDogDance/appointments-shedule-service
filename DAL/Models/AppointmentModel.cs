using Microsoft.EntityFrameworkCore;


namespace DataBase.Models
{
    [Keyless]
    public class AppointmentModel
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int UserId { get; set; }
        public int DoctorId { get; set; }
    }
}
