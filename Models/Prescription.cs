namespace TumainiClinic.Api.Models;

public class Prescription
{
    public int PrescriptionId { get; set; }
    public int ConsultationId { get; set; }
    public Consultation? Consultation { get; set; }
    public DateTime PrescriptionDate { get; set; }
    public string Status { get; set; } = string.Empty;

    public ICollection<PrescriptionItem> PrescriptionItems { get; set; } = new List<PrescriptionItem>();
}