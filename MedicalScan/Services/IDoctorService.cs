using MedicalScan.Models;

namespace MedicalScan.Services
{
    public interface IDoctorService
    {
        Task<List<Specialty>> GetSpecialtiesAsync();
        Task<List<Doctor>> GetDoctorsAsync(string selectedSpecialty);
    }
}
