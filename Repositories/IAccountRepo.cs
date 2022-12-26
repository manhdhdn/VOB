using Microsoft.AspNetCore.Identity;
using VOB.Models;

namespace VOB.Repositories
{
    public interface IAccountRepo
    {
        Task CreateRolesAsync(string roleName);
        Task<IdentityResult> SignUp(SignUpModel signUp);
        Task<SignInRs?> SignIn(string email, string password);
    }
}
