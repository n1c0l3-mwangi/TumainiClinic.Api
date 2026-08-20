namespace TumainiClinic.Api.Models;

public class Visit
{
    public int VisitId { get; set; }
    public int PatientId { get; set; }
    public Patient? Patient { get; set; }
    public DateTime VisitDate { get; set; }
    public string ReasonForVisit { get; set; } = string.Empty;
    public Triage? Triage { get; set; }
    public Consultation? Consultation { get; set; }
    public Bill? Bill { get; set; }

}