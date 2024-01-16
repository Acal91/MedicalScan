using MedicalScan.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalScan.Helpers
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<DoctorSpecialty> DoctorSpecialties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorSpecialty>()
                .HasKey(ds => new { ds.DoctorId, ds.SpecialtyId });

            

            base.OnModelCreating(modelBuilder);
        }
    }
}
