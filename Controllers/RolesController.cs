using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VOB.Data.Context;
using VOB.Repositories;

namespace VOB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IAccountRepo _accountRepo;

        public RolesController(DataContext context,
                               IAccountRepo accountRepo)
        {
            _context = context;
            _accountRepo = accountRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentityRole>>> GetRole()
        {
            return await _context.Roles.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostRole(string? code)
        {
            if (code == null)
            {
                return BadRequest();
            }

            if (code.Equals("Abc@123") && !_context.Roles.Any())
            {
                var roles = new List<string>() { "Admin", "Owner", "Player" };

                foreach (var role in roles)
                {
                    await _accountRepo.CreateRolesAsync(role);
                }

                return CreatedAtAction(nameof(GetRole), null, roles);
            }

            return BadRequest();
        }
    }
}
