namespace TumainiClinic.Api.Models;

public class Medication
{
    public int MedicationId { get; set; }
    public string MedicationName { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }

    public ICollection<PrescriptionItem> PrescriptionItems { get; set; } = new List<PrescriptionItem>();
}