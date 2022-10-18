using domain.Adaptors;
using domain.Entities;

namespace domain.Interactors
{
    public class ScheduleInteractor
    {
        private readonly IScheduleAdaptor _scheduleAdaptor;

        public ScheduleInteractor(IScheduleAdaptor scheduleAdaptor)
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

        public Result<Schedule> EditSchedule(Schedule schedule)
        {
            Schedule? result = _scheduleAdaptor.EditSchedule(schedule);

            return result is null ? Result.Fail<Schedule>("Can not edit schedule") : Result.Ok(result);
        }
    }
}
