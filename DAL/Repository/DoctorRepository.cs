using DataBase.Converters;
using DataBase.Models;
using domain.Adaptors;
using domain.Entities;

namespace DataBase.Repository
{
    public class DoctorRepository : IDoctorAdapter
    {

        private readonly ApplicationContext _context;

        public DoctorRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Doctor? CreateDoctor(int doctorId, string doctorName, Specialization specialization)
        {
            var doctor = new DoctorModel {DoctorId = doctorId, DoctorName = doctorName, SpecializationId = specialization.SpecializationId};

            _context.Doctors.Add(doctor);
            _context.SaveChanges();

            return doctor.ToDomain();
        }

        public bool DeleteDoctor(int doctorId)
        {
            if (HaveAppointmens(doctorId))
                return false;

            var doctor = _context.Doctors.FirstOrDefault(doctor => doctor.DoctorId == doctorId);

            if (doctor is null)
                return false;

            _context.Doctors.Remove(doctor);
            _context.SaveChanges();

            return true;
        }

        public Doctor? GetDoctor(int doctorId)
        {
            var doctor = _context.Doctors.FirstOrDefault(doctor => doctor.DoctorId == doctorId);

            return doctor?.ToDomain();
        }

        public List<Doctor> GetDoctor(Specialization specialization)
        {
            var results = _context.Doctors.Where(doctor => doctor.SpecializationId == specialization.SpecializationId).ToList();

            List<Doctor> doctors = new List<Doctor>();

            foreach(var res in results)
            {
                doctors.Add(res?.ToDomain());

            }

            return doctors;
        }

        public List<Doctor>? GetDoctorList()
        {
            var results = _context.Doctors;

            List<Doctor> doctors = new List<Doctor>();

            foreach (var res in results)
            {
                doctors.Add(res?.ToDomain());
            }

            return doctors;
        }

        public bool HaveAppointmens(int doctorId)
        {
            var appointment = _context.Appointments.FirstOrDefault(appointment => appointment.DoctorId == doctorId);

            return appointment is not null ? true : false;
        }
    }
}
