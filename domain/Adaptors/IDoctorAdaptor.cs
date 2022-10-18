using domain.Entities;

namespace domain.Adaptors
{
    public interface IDoctorAdaptor
    {
        public Doctor? CreateDoctor(Doctor doctor);
        public bool DeleteDoctor(int doctorId);
        public List<Doctor>? GetDoctorList();
        public Doctor? GetDoctor(int doctorId);
        public List<Doctor> GetDoctor(Specialization specialization);
    }
}
