using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VOB.Data;
using VOB.Data.Context;

namespace VOB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly DataContext _context;

        public UnitsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Units
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Unit>>> GetUnit()
        {
            return await _context.Unit.ToListAsync();
        }

        // GET: api/Units/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Unit>> GetUnit(Guid id)
        {
            var unit = await _context.Unit.FindAsync(id);

            if (unit == null)
            {
                return NotFound();
            }

            return unit;
        }

        //// PUT: api/Units/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUnit(Guid id, Unit unit)
        //{
        //    if (id != unit.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(unit).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UnitExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Units
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Unit>> PostUnit(string? code)
        {
            if (code == null)
            {
                return BadRequest();
            }

            if (code.Equals("Abc@123") && !_context.Unit.Any())
            {
                var units = new List<Unit>
                {
                    new Unit()
                    {
                        Id = new Guid(),
                        Name = "Giờ"
                    },

                    new Unit()
                    {
                        Id = new Guid(),
                        Name = "Ngày"
                    },

                    new Unit()
                    {
                        Id = new Guid(),
                        Name = "Tháng"
                    },

                    new Unit()
                    {
                        Id = new Guid(),
                        Name = "Quý"
                    },

                    new Unit()
                    {
                        Id = new Guid(),
                        Name = "Năm"
                    }
                };

                foreach (var unit in units)
                {
                    _context.Unit.Add(unit);
                    await _context.SaveChangesAsync();
                }

                return CreatedAtAction("GetUnit", null, units);
            }

            return BadRequest();
        }

        //// DELETE: api/Units/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUnit(Guid id)
        //{
        //    var unit = await _context.Unit.FindAsync(id);
        //    if (unit == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Unit.Remove(unit);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool UnitExists(Guid id)
        //{
        //    return _context.Unit.Any(e => e.Id == id);
        //}
    }
}
