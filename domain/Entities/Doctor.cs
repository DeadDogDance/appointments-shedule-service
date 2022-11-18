namespace domain.Entities
{
    public class Doctor
    {
        public int DoctorId { get; private set; }
        public string? DoctorName { get; private set; }
        public int SpecializationId { get; private set; }

        public Doctor(int doctorId, string doctorName, int specializationId)
        {
            DoctorId = doctorId;
            DoctorName = doctorName;
            SpecializationId = specializationId;
        }
    }
}
