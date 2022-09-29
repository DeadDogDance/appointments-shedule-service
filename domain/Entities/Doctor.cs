namespace domain.Entities
{
    public class Doctor
    {
        public int DoctorId { get; private set; }
        public string DoctorName { get; private set; }
        public Specialization Specialization { get; private set; }
    }
}
