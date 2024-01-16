namespace MedicalScan.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public List<DoctorSpecialty> DoctorSpecialties { get; set; }
    }
}
