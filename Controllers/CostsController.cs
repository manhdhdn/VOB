using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VOB.Data;
using VOB.Data.Context;

namespace VOB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostsController : ControllerBase
    {
        private readonly DataContext _context;

        public CostsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Costs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cost>>> GetCosts()
        {
            return await _context.Costs.ToListAsync();
        }

        // GET: api/Costs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cost>> GetCost(Guid id)
        {
            var cost = await _context.Costs.FindAsync(id);

            if (cost == null)
            {
                return NotFound();
            }

            return cost;
        }

        // PUT: api/Costs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCost(Guid id, Cost cost)
        {
            if (id != cost.Id)
            {
                return BadRequest();
            }

            _context.Entry(cost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CostExists(id))
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

        // POST: api/Costs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cost>> PostCost(Cost cost)
        {
            _context.Costs.Add(cost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCost", new { id = cost.Id }, cost);
        }

        // DELETE: api/Costs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCost(Guid id)
        {
            var cost = await _context.Costs.FindAsync(id);
            if (cost == null)
            {
                return NotFound();
            }

            _context.Costs.Remove(cost);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CostExists(Guid id)
        {
            return _context.Costs.Any(e => e.Id == id);
        }
    }
}
