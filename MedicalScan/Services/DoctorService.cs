using MedicalScan.Helpers;
using MedicalScan.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalScan.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly AppDbContext _context;

        public DoctorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Specialty>> GetSpecialtiesAsync()
        {
            IQueryable<Specialty> specialtiesQuery = _context.Specialties.OrderBy(s => s.Name);
            return await specialtiesQuery.ToListAsync();
        }

        public async Task<List<Doctor>> GetDoctorsAsync(string selectedSpecialty)
        {
            IQueryable<Doctor> doctorsQuery = _context.Doctors.Include(d => d.DoctorSpecialties).ThenInclude(ds => ds.Specialty);

            if (!string.IsNullOrEmpty(selectedSpecialty))
            {
                int selectedSpecialtyId = int.Parse(selectedSpecialty);
                doctorsQuery = doctorsQuery.Where(d => d.DoctorSpecialties.Any(ds => ds.SpecialtyId == selectedSpecialtyId));
            }

            return await doctorsQuery.OrderBy(d => d.Name).ToListAsync();
        }
    }
}
