using domain.Entities;

namespace domain.Adaptors
{
    public interface IAppointmentAdaptor
    {
        public Appointment? SaveAppointment(DateOnly date);
        public Appointment? SaveAppointment(DateOnly date, Doctor doctor);
        public List<DateOnly> GetFreeAppointmentDateList(Specialization specialization);
    }
}
