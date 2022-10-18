using domain.Adaptors;
using domain.Entities;

namespace domain.Interactors
{
    public class DoctorInteractor
    {
        private readonly IDoctorAdaptor _doctorAdaptor;

        public DoctorInteractor(IDoctorAdaptor doctorAdaptor)
        {
            _doctorAdaptor = doctorAdaptor;
        }

        public Result<Doctor> GetDoctor(int doctorId)
        {
            Doctor? doctor = _doctorAdaptor.GetDoctor(doctorId);

            return doctor is null ? Result.Fail<Doctor>("Doctor not found") : Result.Ok(doctor);
        }
        public Result<List<Doctor>> GetDoctor(Specialization specialization)
        {
            if (string.IsNullOrEmpty(specialization.SpecializationName))
                return Result.Fail<List<Doctor>>("Empty specialization");   

            List<Doctor>? doctors = _doctorAdaptor.GetDoctor(specialization);

            return doctors is null ? Result.Fail<List<Doctor>>("Can not get list of doctors") : Result.Ok(doctors);
        }
        public Result<List<Doctor>> GetDoctorList()
        {
            List<Doctor>? doctors = _doctorAdaptor.GetDoctorList();

            return doctors is null ? Result.Fail<List<Doctor>>("Can not get list of doctors") : Result.Ok(doctors);
        }
        public Result<bool> DeleteDoctor(int doctorId)
        {
            var doctor = _doctorAdaptor.GetDoctor(doctorId);

            if (doctor is null)
                return Result.Fail<bool>("Doctor not found");

            bool result = _doctorAdaptor.DeleteDoctor(doctorId);

            return result ? Result.Ok(result) : Result.Fail<bool>("Doctor not deleted");
        }
        public Result<Doctor> CreateDoctor(Doctor doctor)
        {
            if (string.IsNullOrEmpty(doctor.DoctorName))
                return Result.Fail<Doctor>("Empty doctor name");
            if (doctor.Specialization is null)
                return Result.Fail<Doctor>("No specialization");

            return Result.Ok(doctor);
        }
    }
}
