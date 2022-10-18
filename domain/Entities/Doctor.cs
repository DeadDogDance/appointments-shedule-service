namespace domain.Entities
{
    public class Doctor
    {
        public int DoctorId { get; private set; }
        public string? DoctorName { get; private set; }
        public Specialization? Specialization { get; private set; }

        public Doctor(int doctorId, string doctorName, Specialization specialization)
        {
            DoctorId = doctorId;
            DoctorName = doctorName;
            Specialization = specialization;
        }
    }
}
