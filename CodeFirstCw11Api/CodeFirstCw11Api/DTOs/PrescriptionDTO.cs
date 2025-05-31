namespace CodeFirstCw11Api.DTOs;

public class PrescriptionDTO
{
    public string PatientFirstName { get; set; }
    public string PatientLastName { get; set; }
    public DateTime PatientBirthdate { get; set; }

    public int DoctorId { get; set; }

    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }

    public List<PrescriptionMedicamentDTO> Medicaments { get; set; }
}