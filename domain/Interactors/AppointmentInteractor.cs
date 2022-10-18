
using domain.Adaptors;
using domain.Entities;

namespace domain.Interactors
{
    public class AppointmentInteractor
    {
        private readonly IAppointmentAdaptor _appointmentAdaptor;

        public AppointmentInteractor(IAppointmentAdaptor appointmentAdaptor)
        {
            _appointmentAdaptor = appointmentAdaptor;
        }

        public Result<Appointment> SaveAppointment(DateOnly date)
        {
            Appointment? appointment = _appointmentAdaptor.SaveAppointment(date);

            return appointment is null ? Result.Fail<Appointment>("Can not save appointment") : Result.Ok(appointment);

        }
        public Result<Appointment> SaveAppointment(DateOnly date, Doctor doctor)
        {
            Appointment? appointment = _appointmentAdaptor.SaveAppointment(date, doctor);

            return appointment is null ? Result.Fail<Appointment>("Can not save appointment") : Result.Ok(appointment);

        }
        public Result<List<DateOnly>> GetFreeAppointmentDateList(Specialization specialization)
        {
            List<DateOnly>? dates = _appointmentAdaptor.GetFreeAppointmentDateList(specialization);

            return dates is null ? Result.Fail<List<DateOnly>>("Can not get date list") : Result.Ok(dates);
        }
    }
}
