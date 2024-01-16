using System.Globalization;

namespace MedicalScan.Models
{
    public class Specialty
    {
        public int SpecialtyId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public List<DoctorSpecialty> DoctorSpecialties { get; set; }
    }
}
