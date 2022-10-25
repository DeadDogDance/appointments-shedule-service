namespace domain.Entities
{
    public class Specialization
    {
        public int SpecializationId { get; private set; }
        public string SpecializationName { get; private set; }
        

        public Specialization(int specializationId, string specializationName)
        {
            SpecializationId = specializationId;
            SpecializationName = specializationName;
        }
    }
}
