using DataBase.Converters;
using DataBase.Models;
using domain.Adaptors;
using domain.Entities;

namespace DataBase.Repository
{
    public class AppointmentRepository : IAppointmentAdapter
    {

        private readonly ApplicationContext _context;

        public AppointmentRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Appointment? GetAppointment(DateTime startTime, DateTime endTime)
        {
            var appointment = _context.Appointments.FirstOrDefault(appointment => appointment.StartTime == startTime
                && appointment.EndTime == endTime);

            return appointment?.ToDomain();
        }

        

        public Appointment? SaveAppointment(DateTime startTime, DateTime endTime, User user,Doctor doctor)
        {
            var appointment = new AppointmentModel {
                DoctorId = doctor.DoctorId,
                StartTime = startTime,
                EndTime = endTime,
                UserId = user.UserId,
            };

            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            return appointment.ToDomain();
        }

        public List<DateOnly> GetFreeAppointmentDateList(Specialization specialization)
        {
            var doctors = _context.Doctors.Where(doctor => doctor.SpecializationId == specialization.SpecializationId).ToList();

            var freeAppontments = new List<DateOnly>();
            
            var minimalSpan = new TimeSpan(0, 0, 15);
            
            foreach (var doctor in doctors)
            {
                var doctorAppointments = _context.Appointments.Where(app => app.DoctorId == doctor.DoctorId).ToList();

                for (int i = 1; i < doctorAppointments.Count; i++)
                {
                    if (doctorAppointments[i].StartTime - doctorAppointments[i - 1].EndTime >= minimalSpan)
                    {
                        freeAppontments.Add(DateOnly.FromDateTime(doctorAppointments[i - 1].EndTime));
                        break;
                    }
                }
            }

            
            return freeAppontments;
        }

        public Appointment? SaveAppointment(DateTime startTime, DateTime endTime, User user,Specialization specialization)
        {
            var doctors = _context.Doctors.Where(doctor => doctor.SpecializationId == specialization.SpecializationId).ToList();


            foreach (var doctor in doctors)
            {
                var doctorAppointment = _context.Appointments.Any(app => app.DoctorId == doctor.DoctorId
                    && app.StartTime == startTime
                    && app.EndTime == endTime);

                if (!doctorAppointment)
                {
                    var appointment = new AppointmentModel {
                        StartTime = startTime,
                        EndTime = endTime,
                        DoctorId = doctor.DoctorId,
                        UserId = user.UserId,
                    };

                    _context.Appointments.Add(appointment);
                    _context.SaveChanges();

                    return appointment.ToDomain();

                }
                
            }

            return null;
        }
    }
}
