using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VOB.Data.Context;

namespace VOB.Repositories
{
    public class AccountRepo : IAccountRepo
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountRepo(DataContext dataContext,
                           UserManager<IdentityUser> userManager,
                           SignInManager<IdentityUser> signInManager,
                           IConfiguration configuration)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> SignUp(string email, string roleID, string password)
        {
            var user = new IdentityUser()
            {
                UserName = email,
                Email = email
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                // Add user to role here.
            }

            return result;
        }

        public async Task<string?> SignIn(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, false);

            if (!result.Succeeded)
            {
                return result.IsNotAllowed ? "Require Confirmed Account" : null;
            }

            var user = await _userManager.FindByEmailAsync(email);
            var roleName = (await _userManager.GetRolesAsync(user)).First();

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, email),
                new Claim(ClaimTypes.Role, roleName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var authSignKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(5),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSignKey, SecurityAlgorithms.HmacSha256Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
