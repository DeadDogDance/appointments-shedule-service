using domain.Entities;

namespace domain.Adaptors
{
    public interface IScheduleAdaptor
    {
        public Schedule? GetDoctorScheduleByDate(Doctor doctor, DateOnly date);
        public Schedule? AddSchedule(Schedule schedule);
        public Schedule? EditSchedule(Schedule schedule);
    }
}
