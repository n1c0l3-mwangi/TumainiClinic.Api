using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TumainiClinic.Api.Models;
using TumainiClinic.Api.Data;

[Route("api/[controller]")]
[ApiController]
public class PrescriptionItemsController : ControllerBase
{
    private readonly ClinicDbContext _context;
    public PrescriptionItemsController(ClinicDbContext context)
    {
        _context = context;
    }

    // GET: api/PrescriptionItem
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PrescriptionItem>>> GetPrescriptionItem()
    {
        return await _context.PrescriptionItems.ToListAsync();
    }

    // GET: api/PrescriptionItem/5
    [HttpGet("{prescriptionitemid}")]
    public async Task<ActionResult<PrescriptionItem>> GetPrescriptionItem(int prescriptionitemid)
    {
        var prescriptionitem = await _context.PrescriptionItems.FindAsync(prescriptionitemid);

        if (prescriptionitem == null)
        {
            return NotFound();
        }

        return prescriptionitem;
    }

    // PUT: api/PrescriptionItem/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{prescriptionitemid}")]
    public async Task<IActionResult> PutPrescriptionItem(int? prescriptionitemid, PrescriptionItem prescriptionitem)
    {
        if (prescriptionitemid != prescriptionitem.PrescriptionItemId)
        {
            return BadRequest();
        }

        _context.Entry(prescriptionitem).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PrescriptionItemExists(prescriptionitemid))
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

    // POST: api/PrescriptionItem
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<PrescriptionItem>> PostPrescriptionItem(PrescriptionItem prescriptionitem)
    {
        _context.PrescriptionItems.Add(prescriptionitem);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPrescriptionItem", new { prescriptionitemid = prescriptionitem.PrescriptionItemId }, prescriptionitem);
    }

    // DELETE: api/PrescriptionItem/5
    [HttpDelete("{prescriptionitemid}")]
    public async Task<IActionResult> DeletePrescriptionItem(int? prescriptionitemid)
    {
        var prescriptionitem = await _context.PrescriptionItems.FindAsync(prescriptionitemid);
        if (prescriptionitem == null)
        {
            return NotFound();
        }

        _context.PrescriptionItems.Remove(prescriptionitem);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PrescriptionItemExists(int? prescriptionitemid)
    {
        return _context.PrescriptionItems.Any(e => e.PrescriptionItemId == prescriptionitemid);
    }
}
