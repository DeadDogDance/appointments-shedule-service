using domain.Adaptors;
using domain.Entities;

namespace domain.Interactors
{
    public class ScheduleInteractor
    {
        private readonly IScheduleAdapter _scheduleAdaptor;

        public ScheduleInteractor(IScheduleAdapter scheduleAdaptor)
        {
            _scheduleAdaptor = scheduleAdaptor;
        }

        public Result<Schedule> GetDoctorScheduleByDate(Doctor doctor, DateOnly date)
        {
            Schedule? schedule = _scheduleAdaptor.GetDoctorScheduleByDate(doctor, date);

            return schedule is null ? Result.Fail<Schedule>("Schedule not found") : Result.Ok(schedule);
        }

        public Result<Schedule> AddSchedule(Schedule schedule)
        {
            Schedule? result = _scheduleAdaptor.AddSchedule(schedule);

            return result is null ? Result.Fail<Schedule>("Can not add schedule") : Result.Ok(schedule);
        }

        public Result<Schedule> EditSchedule(Schedule oldSchedule, Schedule newSchedule)
        {
            Schedule? result = _scheduleAdaptor.EditSchedule(oldSchedule, newSchedule);

            return result is null ? Result.Fail<Schedule>("Can not edit schedule") : Result.Ok(result);
        }
    }
}
