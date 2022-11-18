using System.ComponentModel.DataAnnotations;

namespace DataBase.Models
{
    public class DoctorModel
    {
        [Key]
        public int DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public int SpecializationId { get; set; }
    }
}
