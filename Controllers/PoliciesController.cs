using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VOB.Data;
using VOB.Data.Context;

namespace VOB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        private readonly DataContext _context;

        public PoliciesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Policies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Policy>>> GetPolicy()
        {
            return await _context.Policy.ToListAsync();
        }

        // GET: api/Policies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Policy>> GetPolicy(Guid id)
        {
            var policy = await _context.Policy.FindAsync(id);

            if (policy == null)
            {
                return NotFound();
            }

            return policy;
        }

        //// PUT: api/Policies/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPolicy(Guid id, Policy policy)
        //{
        //    if (id != policy.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(policy).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PolicyExists(id))
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

        // POST: api/Policies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Policy>> PostPolicy(string? code)
        {
            if (code == null)
            {
                return BadRequest();
            }

            if (code.Equals("Abc@123") && !_context.Policy.Any())
            {
                var policies = new List<Policy>
                {
                    new Policy()
                    {
                        Id = new Guid(),
                        Name = "Linh hoạt",
                        Description = "Quý khách hàng có thể hủy lịch đặt sân trong vòng 24h trước khi đến hẹn sử dụng sân và sẽ được hoàn trả 100% số tiền đã thanh toán trên hệ thống. Trong trường hợp không đến sân như đã đặt lịch hẹn trước, quý khách sẽ được hoàn trả 50% số tiền đã thanh toán."
                    },
                    new Policy()
                    {
                        Id = new Guid(),
                        Name = "Phổ thông",
                        Description = "Quý khách hàng có thể hủy lịch đặt sân trong vòng 120h (tức 5 ngày) trước khi đến hẹn sử dụng sân và sẽ được hoàn trả 100% số tiền đã thanh toán trên hệ thống. Trong trường hợp không đến sân như đã đặt lịch hẹn trước, quý khách sẽ được hoàn trả 30% số tiền đã thanh toán."
                    },
                    new Policy()
                    {
                        Id = new Guid(),
                        Name = "Khắt khe",
                        Description = "Quý khách hàng có thể hủy lịch đặt sân trong vòng 168h (tức 7 ngày) trước khi đến hẹn sử dụng sân và sẽ được hoàn trả 100% số tiền đã thanh toán trên hệ thống. Trong trường hợp không đến sân như đã đặt lịch hẹn trước, quý khách sẽ không được hoàn trả số tiền đã thanh toán."
                    }
                };

                foreach (var policy in policies)
                {
                    _context.Policy.Add(policy);
                    await _context.SaveChangesAsync();
                }

                return CreatedAtAction("GetPolicy", null, policies);
            }

            return BadRequest();
        }

        //// DELETE: api/Policies/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePolicy(Guid id)
        //{
        //    var policy = await _context.Policy.FindAsync(id);
        //    if (policy == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Policy.Remove(policy);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool PolicyExists(Guid id)
        //{
        //    return _context.Policy.Any(e => e.Id == id);
        //}
    }
}
