using domain.Adaptors;
using domain.Entities;

namespace domain.Interactors
{
    public class AppointmentInteractor
    {
        private readonly IAppointmentAdapter _appointmentAdaptor;

        public AppointmentInteractor(IAppointmentAdapter appointmentAdaptor)
        {
            _appointmentAdaptor = appointmentAdaptor;
        }

        public Result<Appointment> SaveAppointment(DateTime startTime, DateTime endTime, User user,Specialization specialization)
        {
            if (startTime > endTime)
                return Result.Fail<Appointment>("End of appointment should be after the start");

            Appointment? existedAppointment = _appointmentAdaptor.GetAppointment(startTime, endTime);

            if (existedAppointment is not null)
                return Result.Fail<Appointment>("This time reserved");

            Appointment? appointment = _appointmentAdaptor.SaveAppointment(startTime, endTime, user, specialization);

            return appointment is null ? Result.Fail<Appointment>("Can not save appointment") : Result.Ok(appointment);

        }
        public Result<Appointment> SaveAppointment(DateTime startTime, DateTime endTime, User user, Doctor doctor)
        {
            if (startTime > endTime)
                return Result.Fail<Appointment>("End of appointment should be after the start");

            Appointment? existedAppointment = _appointmentAdaptor.GetAppointment(startTime, endTime);

            if (existedAppointment is not null)
                return Result.Fail<Appointment>("This time reserved");


            Appointment? appointment = _appointmentAdaptor.SaveAppointment(startTime, endTime, user, doctor);

            return appointment is null ? Result.Fail<Appointment>("Can not save appointment") : Result.Ok(appointment);

        }
        public Result<List<DateOnly>> GetFreeAppointmentDateList(Specialization specialization)
        {
            List<DateOnly>? dates = _appointmentAdaptor.GetFreeAppointmentDateList(specialization);

            return dates is null ? Result.Fail<List<DateOnly>>("Can not get date list") : Result.Ok(dates);
        }
    }
}
