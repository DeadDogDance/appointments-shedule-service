using domain.Entities;

namespace domain.Adaptors
{
    public interface IAppointmentAdapter
    {
        public Appointment? SaveAppointment(DateTime startTime, DateTime endTime, User user, Specialization specialization);
        public Appointment? SaveAppointment(DateTime startTime, DateTime endTime, User user, Doctor doctor);
        public List<DateOnly> GetFreeAppointmentDateList(Specialization specialization);
        public Appointment? GetAppointment(DateTime startTime, DateTime endTime);
    }
}
