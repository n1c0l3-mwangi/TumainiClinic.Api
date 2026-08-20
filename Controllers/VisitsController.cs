using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TumainiClinic.Api.Models;
using TumainiClinic.Api.Data;

[Route("api/[controller]")]
[ApiController]
public class VisitsController : ControllerBase
{
    private readonly ClinicDbContext _context;
    public VisitsController(ClinicDbContext context)
    {
        _context = context;
    }

    // GET: api/Visit
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Visit>>> GetVisit()
    {
        return await _context.Visits.ToListAsync();
    }

    // GET: api/Visit/5
    [HttpGet("{visitid}")]
    public async Task<ActionResult<Visit>> GetVisit(int visitid)
    {
        var visit = await _context.Visits.FindAsync(visitid);

        if (visit == null)
        {
            return NotFound();
        }

        return visit;
    }

    // PUT: api/Visit/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{visitid}")]
    public async Task<IActionResult> PutVisit(int? visitid, Visit visit)
    {
        if (visitid != visit.VisitId)
        {
            return BadRequest();
        }

        _context.Entry(visit).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VisitExists(visitid))
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

    // POST: api/Visit
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Visit>> PostVisit(Visit visit)
    {
        _context.Visits.Add(visit);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetVisit", new { visitid = visit.VisitId }, visit);
    }

    // DELETE: api/Visit/5
    [HttpDelete("{visitid}")]
    public async Task<IActionResult> DeleteVisit(int? visitid)
    {
        var visit = await _context.Visits.FindAsync(visitid);
        if (visit == null)
        {
            return NotFound();
        }

        _context.Visits.Remove(visit);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool VisitExists(int? visitid)
    {
        return _context.Visits.Any(e => e.VisitId == visitid);
    }
}
