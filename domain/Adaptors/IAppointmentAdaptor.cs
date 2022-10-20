using domain.Entities;

namespace domain.Adaptors
{
    public interface IAppointmentAdaptor
    {
        public Appointment? SaveAppointment(DateTime startTime, DateTime endTime);
        public Appointment? SaveAppointment(DateTime startTime, DateTime endTime, Doctor doctor);
        public List<DateOnly> GetFreeAppointmentDateList(Specialization specialization);
    }
}
