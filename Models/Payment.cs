namespace TumainiClinic.Api.Models;

public class Payment
{
    public int PaymentId { get; set; }
    public int BillId { get; set; }
    public Bill? Bill { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public decimal AmountPaid { get; set; }
    public DateTime PaymentDate { get; set; }
}