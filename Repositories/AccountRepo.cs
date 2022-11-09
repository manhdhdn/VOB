using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VOB.Models;

namespace VOB.Repositories
{
    public class AccountRepo : IAccountRepo
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AccountRepo(UserManager<ApplicationUser> userManager,
                           SignInManager<ApplicationUser> signInManager,
                           RoleManager<IdentityRole> roleManager,
                           IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task CreateRolesAsync(string roleName)
        {
            var roleExit = await _roleManager.RoleExistsAsync(roleName);

            if (!roleExit)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        public async Task<IdentityResult> SignUp(SignUpModel signUp)
        {
            var user = new ApplicationUser()
            {
                UserName = signUp.Email,
                Email = signUp.Email,
                FirstName = signUp.FirstName,
                LastName = signUp.LastName,
                PhoneNumber = signUp.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, signUp.Password);

            if (result.Succeeded)
            {
                result = await _userManager.AddToRoleAsync(user, (await _roleManager.FindByIdAsync(signUp.RoleId)).Name);
            }

            return result;
        }

        public async Task<SignInRs?> SignIn(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, false);

            if (!result.Succeeded)
            {
                return result.IsNotAllowed ?
                    new SignInRs()
                    {
                        User = null,
                        Token = "Require confirmed account"
                    }
                    : null;
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

            return new SignInRs()
            {
                User = user,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
    }
}
