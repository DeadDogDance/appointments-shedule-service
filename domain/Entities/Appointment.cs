namespace domain.Entities
{
    public class Appointment
    {
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public int UserId { get; private set; }
        public int DoctorId { get; private set; }

        public Appointment(DateTime startTime, DateTime endTime, int userId, int doctorId)
        {
            StartTime = startTime;
            EndTime = endTime;
            UserId = userId;
            DoctorId = doctorId;
        }
    }
}
