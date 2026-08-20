using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TumainiClinic.Api.Models;
using TumainiClinic.Api.Data;

[Route("api/[controller]")]
[ApiController]
public class BillsController : ControllerBase
{
    private readonly ClinicDbContext _context;
    public BillsController(ClinicDbContext context)
    {
        _context = context;
    }

    // GET: api/Bill
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bill>>> GetBill()
    {
        return await _context.Bills.ToListAsync();
    }

    // GET: api/Bill/5
    [HttpGet("{billid}")]
    public async Task<ActionResult<Bill>> GetBill(int billid)
    {
        var bill = await _context.Bills.FindAsync(billid);

        if (bill == null)
        {
            return NotFound();
        }

        return bill;
    }

    // PUT: api/Bill/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{billid}")]
    public async Task<IActionResult> PutBill(int? billid, Bill bill)
    {
        if (billid != bill.BillId)
        {
            return BadRequest();
        }

        _context.Entry(bill).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BillExists(billid))
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

    // POST: api/Bill
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Bill>> PostBill(Bill bill)
    {
        _context.Bills.Add(bill);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetBill", new { billid = bill.BillId }, bill);
    }

    // DELETE: api/Bill/5
    [HttpDelete("{billid}")]
    public async Task<IActionResult> DeleteBill(int? billid)
    {
        var bill = await _context.Bills.FindAsync(billid);
        if (bill == null)
        {
            return NotFound();
        }

        _context.Bills.Remove(bill);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool BillExists(int? billid)
    {
        return _context.Bills.Any(e => e.BillId == billid);
    }
}
