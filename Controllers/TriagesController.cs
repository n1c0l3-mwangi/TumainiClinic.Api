using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TumainiClinic.Api.Models;
using TumainiClinic.Api.Data;

[Route("api/[controller]")]
[ApiController]
public class TriagesController : ControllerBase
{
    private readonly ClinicDbContext _context;
    public TriagesController(ClinicDbContext context)
    {
        _context = context;
    }

    // GET: api/Triage
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Triage>>> GetTriage()
    {
        return await _context.Triages.ToListAsync();
    }

    // GET: api/Triage/5
    [HttpGet("{triageid}")]
    public async Task<ActionResult<Triage>> GetTriage(int triageid)
    {
        var triage = await _context.Triages.FindAsync(triageid);

        if (triage == null)
        {
            return NotFound();
        }

        return triage;
    }

    // PUT: api/Triage/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{triageid}")]
    public async Task<IActionResult> PutTriage(int? triageid, Triage triage)
    {
        if (triageid != triage.TriageId)
        {
            return BadRequest();
        }

        _context.Entry(triage).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TriageExists(triageid))
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

    // POST: api/Triage
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Triage>> PostTriage(Triage triage)
    {
        _context.Triages.Add(triage);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTriage", new { triageid = triage.TriageId }, triage);
    }

    // DELETE: api/Triage/5
    [HttpDelete("{triageid}")]
    public async Task<IActionResult> DeleteTriage(int? triageid)
    {
        var triage = await _context.Triages.FindAsync(triageid);
        if (triage == null)
        {
            return NotFound();
        }

        _context.Triages.Remove(triage);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TriageExists(int? triageid)
    {
        return _context.Triages.Any(e => e.TriageId == triageid);
    }
}
