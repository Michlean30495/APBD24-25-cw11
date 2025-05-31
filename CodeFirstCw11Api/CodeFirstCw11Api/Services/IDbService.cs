using CodeFirstCw11Api.DTOs;

namespace CodeFirstCw11Api.Services;

public interface IDbService
{
    Task AddPrescriptionAsync(PrescriptionDTO request);
    Task<PatientDTO?> GetPatientDetailsAsync(int idPatient);
}