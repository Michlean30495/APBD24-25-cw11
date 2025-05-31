using CodeFirstCw11Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstCw11Api.Data;

public class HelfcareDbContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    
    public HelfcareDbContext(DbContextOptions<HelfcareDbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PrescriptionMedicament>()
            .HasKey(pm => new { pm.IdMedicament, pm.IdPrescription });
        modelBuilder.Entity<Doctor>()
            .HasKey(doctor => doctor.IdDoctor);
        modelBuilder.Entity<Medicament>()
            .HasKey(medicament => medicament.IdMedicament);
        modelBuilder.Entity<Prescription>()
            .HasKey(Prescription => Prescription.IdPrescription);
        modelBuilder.Entity<Patient>()
            .HasKey(patient => patient.IdPatient);
    }
}