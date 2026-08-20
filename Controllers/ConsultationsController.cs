using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TumainiClinic.Api.Models;
using TumainiClinic.Api.Data;

[Route("api/[controller]")]
[ApiController]
public class ConsultationsController : ControllerBase
{
    private readonly ClinicDbContext _context;
    public ConsultationsController(ClinicDbContext context)
    {
        _context = context;
    }

    // GET: api/Consultation
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Consultation>>> GetConsultation()
    {
        return await _context.Consultations.ToListAsync();
    }

    // GET: api/Consultation/5
    [HttpGet("{consultationid}")]
    public async Task<ActionResult<Consultation>> GetConsultation(int consultationid)
    {
        var consultation = await _context.Consultations.FindAsync(consultationid);

        if (consultation == null)
        {
            return NotFound();
        }

        return consultation;
    }

    // PUT: api/Consultation/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{consultationid}")]
    public async Task<IActionResult> PutConsultation(int? consultationid, Consultation consultation)
    {
        if (consultationid != consultation.ConsultationId)
        {
            return BadRequest();
        }

        _context.Entry(consultation).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ConsultationExists(consultationid))
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

    // POST: api/Consultation
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Consultation>> PostConsultation(Consultation consultation)
    {
        _context.Consultations.Add(consultation);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetConsultation", new { consultationid = consultation.ConsultationId }, consultation);
    }

    // DELETE: api/Consultation/5
    [HttpDelete("{consultationid}")]
    public async Task<IActionResult> DeleteConsultation(int? consultationid)
    {
        var consultation = await _context.Consultations.FindAsync(consultationid);
        if (consultation == null)
        {
            return NotFound();
        }

        _context.Consultations.Remove(consultation);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ConsultationExists(int? consultationid)
    {
        return _context.Consultations.Any(e => e.ConsultationId == consultationid);
    }
}
