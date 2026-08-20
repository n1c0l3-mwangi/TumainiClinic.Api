using System.Numerics;

namespace TumainiClinic.Api.Models;

public class Department
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; } = string.Empty;

    public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    public ICollection<Triage> Triages { get; set; } = new List<Triage>();
}