using domain.Entities;

namespace domain.Adaptors
{
    public interface IDoctorAdapter
    {
        public Doctor? CreateDoctor(int doctorId, string doctorName, Specialization specialization);
        public bool DeleteDoctor(int doctorId);
        public List<Doctor>? GetDoctorList();
        public Doctor? GetDoctor(int doctorId);
        public List<Doctor> GetDoctor(Specialization specialization);
        public bool HaveAppointmens(int doctorId);
        
    }
}
