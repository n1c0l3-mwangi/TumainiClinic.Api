namespace TumainiClinic.Api.Models;

public class Doctor
{
    public int DoctorId { get; set; }
    public int DepartmentId { get; set; }
    public Department? Department { get; set; }
    public string DoctorName { get; set; } = string.Empty;
    public string Specialization { get; set; } = string.Empty;
    public ICollection<Consultation> Consultations { get; set; } = new List<Consultation>();
}