namespace TumainiClinic.Api.Models;

public class Patient
{
    public int PatientId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    public ICollection<Visit> Visits { get; set; } = new List<Visit>();
}