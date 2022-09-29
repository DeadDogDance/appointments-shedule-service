namespace domain.Entities
{
    public class Schedule
    {
        public int DoctorId { get; private set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
