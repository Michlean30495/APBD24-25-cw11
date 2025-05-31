using CodeFirstCw11Api.Data;
using CodeFirstCw11Api.DTOs;
using CodeFirstCw11Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstCw11Api.Services;

public class DbService : IDbService
{
    public readonly HelfcareDbContext _context;

    public DbService(HelfcareDbContext context)
    {
        _context = context;
    }

    public async Task AddPrescriptionAsync(PrescriptionDTO request)
    {
        if (request.Medicaments.Count > 10)
            throw new Exception("wiecej niz 10 lekow");

        if (request.DueDate < request.Date)
            throw new Exception("duedate < date");

        var leki = request.Medicaments
            .Select(m => m.IdMedicament)
            .ToList();
        foreach (var medicament in leki)
        {
            var czyIstnieje = _context.Medicaments.Any(m => m.IdMedicament == medicament);
            if (!czyIstnieje)
                throw new Exception(medicament + " nie istnieje lek o takim id");
        }
        

        var patient = _context.Patients.FirstOrDefault(p =>
            p.FirstName == request.PatientFirstName &&
            p.LastName == request.PatientLastName &&
            p.Birthdate == request.PatientBirthdate);

        if (patient == null)
        {
            patient = new Patient
            {
                FirstName = request.PatientFirstName,
                LastName = request.PatientLastName,
                Birthdate = request.PatientBirthdate
            };
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        var prescription = new Prescription
        {
            Date = request.Date,
            DueDate = request.DueDate,
            IdDoctor = request.DoctorId,
            IdPatient = patient.IdPatient,
            PrescriptionMedicaments = request.Medicaments.Select(m => new PrescriptionMedicament
            {
                IdMedicament = m.IdMedicament,
                Dose = m.Dose,
                Description = m.Description
            }).ToList()
        };

        _context.Prescriptions.Add(prescription);
        await _context.SaveChangesAsync();
    }

    public async Task<PatientDTO?> GetPatientDetailsAsync(int idPatient)
    {
        var patient = await _context.Patients
            .Where(p => p.IdPatient == idPatient)
            .Select(p => new PatientDTO
            {
                IdPatient = p.IdPatient,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Birthdate = p.Birthdate,
                Prescriptions = p.Prescriptions
                    .OrderBy(r => r.DueDate)
                    .Select(r => new PrescriptionPartialDTO()
                    {
                        IdPrescription = r.IdPrescription,
                        Date = r.Date,
                        DueDate = r.DueDate,
                        Doctor = new DoctorDTO
                        {
                            IdDoctor = r.Doctor.IdDoctor,
                            FirstName = r.Doctor.FirstName,
                            LastName = r.Doctor.LastName,
                            Email = r.Doctor.Email
                        },
                        Medicaments = r.PrescriptionMedicaments.Select(pm => new MedicamentDTO()
                        {
                            IdMedicament = pm.Medicament.IdMedicament,
                            Name = pm.Medicament.Name,
                            Description = pm.Medicament.Description,
                            Type = pm.Medicament.Type,
                            Dose = pm.Dose
                        }).ToList()
                    }).ToList()
            })
            .FirstOrDefaultAsync();

        return patient;
    
    }
}