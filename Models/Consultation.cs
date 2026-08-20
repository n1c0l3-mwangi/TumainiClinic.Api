namespace TumainiClinic.Api.Models;

public class Consultation
{
    public int ConsultationId { get; set; }
    public int VisitId { get; set; }
    public Visit? Visit { get; set; }
    public int DoctorId { get; set; }
    public Doctor? Doctor { get; set; }
    public DateTime ConsultationDate { get; set; }
    public string Diagnosis { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public decimal ConsultationCharge { get; set; }
    public Prescription? Prescription { get; set; }

}