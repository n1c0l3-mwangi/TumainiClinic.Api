namespace TumainiClinic.Api.Models;

public class Bill
{
    public int BillId { get; set; }
    public int VisitId { get; set; }
    public Visit? Visit { get; set; }
    public decimal ConsultationCharge { get; set; }
    public decimal MedicationCharge { get; set; }
    public decimal LabTestCharge { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime BillingDate { get; set; }

    public Payment? Payment { get; set; }
}