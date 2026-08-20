using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TumainiClinic.Api.Models;
using TumainiClinic.Api.Data;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly ClinicDbContext _context;
    public PatientsController(ClinicDbContext context)
    {
        _context = context;
    }

    // GET: api/Patient
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Patient>>> GetPatient()
    {
        return await _context.Patients.ToListAsync();
    }

    // GET: api/Patient/5
    [HttpGet("{patientid}")]
    public async Task<ActionResult<Patient>> GetPatient(int patientid)
    {
        var patient = await _context.Patients.FindAsync(patientid);

        if (patient == null)
        {
            return NotFound();
        }

        return patient;
    }

    // PUT: api/Patient/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{patientid}")]
    public async Task<IActionResult> PutPatient(int? patientid, Patient patient)
    {
        if (patientid != patient.PatientId)
        {
            return BadRequest();
        }

        _context.Entry(patient).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PatientExists(patientid))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Patient
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Patient>> PostPatient(Patient patient)
    {
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPatient", new { patientid = patient.PatientId }, patient);
    }

    // DELETE: api/Patient/5
    [HttpDelete("{patientid}")]
    public async Task<IActionResult> DeletePatient(int? patientid)
    {
        var patient = await _context.Patients.FindAsync(patientid);
        if (patient == null)
        {
            return NotFound();
        }

        _context.Patients.Remove(patient);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PatientExists(int? patientid)
    {
        return _context.Patients.Any(e => e.PatientId == patientid);
    }
}
