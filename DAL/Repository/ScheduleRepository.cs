using DataBase.Converters;
using DataBase.Models;

using domain.Adaptors;
using domain.Entities;

namespace DataBase.Repository
{
    public class ScheduleRepository : IScheduleAdapter
    {

        private readonly ApplicationContext _context;

        public ScheduleRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Schedule? AddSchedule(Schedule schedule)
        {
            var newSchedule = new ScheduleModel
            {
                DoctorId = schedule.DoctorId,
                Start = schedule.Start,
                End = schedule.End,
            };

            _context.Schedules.Add(newSchedule);
            _context.SaveChanges();


            return schedule;
        }

        public Schedule? EditSchedule(Schedule oldSchedule, Schedule newSchedule)
        {
            var schedule = _context.Schedules.FirstOrDefault(schedule => schedule.DoctorId == oldSchedule.DoctorId
                && schedule.Start == newSchedule.Start);

            _context.Schedules.Remove(schedule);
            _context.SaveChanges();


            var editedSchedule = new ScheduleModel {
                DoctorId = newSchedule.DoctorId,
                Start = newSchedule.Start,
                End = newSchedule.End,
            };

            _context.Schedules.Add(editedSchedule);
            _context.SaveChanges();


            return newSchedule;
        }

        public Schedule? GetDoctorScheduleByDate(Doctor doctor, DateOnly date)
        {
            var schedule = _context.Schedules.FirstOrDefault(schedule => schedule.DoctorId == doctor.DoctorId
                && (date.Equals(DateOnly.FromDateTime(schedule.Start)) || date.Equals(DateOnly.FromDateTime(schedule.End))));

            return schedule?.ToDomain();
        }

    }
}
