using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TumainiClinic.Api.Models;
using TumainiClinic.Api.Data;

[Route("api/[controller]")]
[ApiController]
public class MedicationsController : ControllerBase
{
    private readonly ClinicDbContext _context;
    public MedicationsController(ClinicDbContext context)
    {
        _context = context;
    }

    // GET: api/Medication
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Medication>>> GetMedication()
    {
        return await _context.Medications.ToListAsync();
    }

    // GET: api/Medication/5
    [HttpGet("{medicationid}")]
    public async Task<ActionResult<Medication>> GetMedication(int medicationid)
    {
        var medication = await _context.Medications.FindAsync(medicationid);

        if (medication == null)
        {
            return NotFound();
        }

        return medication;
    }

    // PUT: api/Medication/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{medicationid}")]
    public async Task<IActionResult> PutMedication(int? medicationid, Medication medication)
    {
        if (medicationid != medication.MedicationId)
        {
            return BadRequest();
        }

        _context.Entry(medication).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MedicationExists(medicationid))
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

    // POST: api/Medication
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Medication>> PostMedication(Medication medication)
    {
        _context.Medications.Add(medication);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetMedication", new { medicationid = medication.MedicationId }, medication);
    }

    // DELETE: api/Medication/5
    [HttpDelete("{medicationid}")]
    public async Task<IActionResult> DeleteMedication(int? medicationid)
    {
        var medication = await _context.Medications.FindAsync(medicationid);
        if (medication == null)
        {
            return NotFound();
        }

        _context.Medications.Remove(medication);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MedicationExists(int? medicationid)
    {
        return _context.Medications.Any(e => e.MedicationId == medicationid);
    }
}
