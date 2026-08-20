namespace TumainiClinic.Api.Models;

public class Triage
{
    public int TriageId { get; set; }
    public int VisitId { get; set; }
    public Visit? Visit { get; set; }
    public decimal Temperature { get; set; }
    public string BloodPressure { get; set; } = string.Empty;
    public decimal Weight { get; set; }
    public decimal Height { get; set; }
    public string ReasonForVisit { get; set; } = string.Empty;
    public int DepartmentId { get; set; }
    public Department? Department { get; set; }
}