using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TumainiClinic.Api.Models;
using TumainiClinic.Api.Data;

[Route("api/[controller]")]
[ApiController]
public class PrescriptionsController : ControllerBase
{
    private readonly ClinicDbContext _context;
    public PrescriptionsController(ClinicDbContext context)
    {
        _context = context;
    }

    // GET: api/Prescription
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Prescription>>> GetPrescription()
    {
        return await _context.Prescriptions.ToListAsync();
    }

    // GET: api/Prescription/5
    [HttpGet("{prescriptionid}")]
    public async Task<ActionResult<Prescription>> GetPrescription(int prescriptionid)
    {
        var prescription = await _context.Prescriptions.FindAsync(prescriptionid);

        if (prescription == null)
        {
            return NotFound();
        }

        return prescription;
    }

    // PUT: api/Prescription/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{prescriptionid}")]
    public async Task<IActionResult> PutPrescription(int? prescriptionid, Prescription prescription)
    {
        if (prescriptionid != prescription.PrescriptionId)
        {
            return BadRequest();
        }

        _context.Entry(prescription).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PrescriptionExists(prescriptionid))
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

    // POST: api/Prescription
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Prescription>> PostPrescription(Prescription prescription)
    {
        _context.Prescriptions.Add(prescription);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPrescription", new { prescriptionid = prescription.PrescriptionId }, prescription);
    }

    // DELETE: api/Prescription/5
    [HttpDelete("{prescriptionid}")]
    public async Task<IActionResult> DeletePrescription(int? prescriptionid)
    {
        var prescription = await _context.Prescriptions.FindAsync(prescriptionid);
        if (prescription == null)
        {
            return NotFound();
        }

        _context.Prescriptions.Remove(prescription);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PrescriptionExists(int? prescriptionid)
    {
        return _context.Prescriptions.Any(e => e.PrescriptionId == prescriptionid);
    }
}
