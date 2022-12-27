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
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AccountRepo(UserManager<User> userManager,
                           SignInManager<User> signInManager,
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
            var roleExist = await _roleManager.RoleExistsAsync(roleName);

            if (!roleExist)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel signUp)
        {
            var user = new User()
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

        public async Task<SignInRs?> SignInAsync(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, false);

            if (!result.Succeeded)
            {
                return new SignInRs()
                {
                    User = null,
                    Token = result.ToString()
                };
            }

            var user = await _userManager.FindByEmailAsync(email);
            var roleName = (await _userManager.GetRolesAsync(user)).First();

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, email),
                new Claim(ClaimTypes.Role, roleName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) //Guid
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
