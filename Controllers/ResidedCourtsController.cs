using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VOB.Data;
using VOB.Data.Context;

namespace VOB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidedCourtsController : ControllerBase
    {
        private readonly DataContext _context;

        public ResidedCourtsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ResidedCourts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResidedCourt>>> GetResidedCourt()
        {
            return await _context.ResidedCourt.ToListAsync();
        }

        // GET: api/ResidedCourts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResidedCourt>> GetResidedCourt(Guid id)
        {
            var residedCourt = await _context.ResidedCourt.FindAsync(id);

            if (residedCourt == null)
            {
                return NotFound();
            }

            return residedCourt;
        }

        // PUT: api/ResidedCourts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResidedCourt(Guid id, ResidedCourt residedCourt)
        {
            if (id != residedCourt.Id)
            {
                return BadRequest();
            }

            _context.Entry(residedCourt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResidedCourtExists(id))
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

        // POST: api/ResidedCourts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResidedCourt>> PostResidedCourt(ResidedCourt residedCourt)
        {
            _context.ResidedCourt.Add(residedCourt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResidedCourt", new { id = residedCourt.Id }, residedCourt);
        }

        // DELETE: api/ResidedCourts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResidedCourt(Guid id)
        {
            var residedCourt = await _context.ResidedCourt.FindAsync(id);
            if (residedCourt == null)
            {
                return NotFound();
            }

            _context.ResidedCourt.Remove(residedCourt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResidedCourtExists(Guid id)
        {
            return _context.ResidedCourt.Any(e => e.Id == id);
        }
    }
}
