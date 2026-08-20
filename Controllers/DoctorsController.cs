using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TumainiClinic.Api.Models;
using TumainiClinic.Api.Data;

[Route("api/[controller]")]
[ApiController]
public class DoctorsController : ControllerBase
{
    private readonly ClinicDbContext _context;
    public DoctorsController(ClinicDbContext context)
    {
        _context = context;
    }

    // GET: api/Doctor
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctor()
    {
        return await _context.Doctors.ToListAsync();
    }

    // GET: api/Doctor/5
    [HttpGet("{doctorid}")]
    public async Task<ActionResult<Doctor>> GetDoctor(int doctorid)
    {
        var doctor = await _context.Doctors.FindAsync(doctorid);

        if (doctor == null)
        {
            return NotFound();
        }

        return doctor;
    }

    // PUT: api/Doctor/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{doctorid}")]
    public async Task<IActionResult> PutDoctor(int? doctorid, Doctor doctor)
    {
        if (doctorid != doctor.DoctorId)
        {
            return BadRequest();
        }

        _context.Entry(doctor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DoctorExists(doctorid))
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

    // POST: api/Doctor
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
    {
        _context.Doctors.Add(doctor);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetDoctor", new { doctorid = doctor.DoctorId }, doctor);
    }

    // DELETE: api/Doctor/5
    [HttpDelete("{doctorid}")]
    public async Task<IActionResult> DeleteDoctor(int? doctorid)
    {
        var doctor = await _context.Doctors.FindAsync(doctorid);
        if (doctor == null)
        {
            return NotFound();
        }

        _context.Doctors.Remove(doctor);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool DoctorExists(int? doctorid)
    {
        return _context.Doctors.Any(e => e.DoctorId == doctorid);
    }
}
