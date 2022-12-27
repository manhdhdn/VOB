using Microsoft.AspNetCore.Identity;
using VOB.Models;

namespace VOB.Repositories
{
    public interface IAccountRepo
    {
        Task CreateRolesAsync(string roleName);
        Task<IdentityResult> SignUpAsync(SignUpModel signUp);
        Task<SignInRs?> SignInAsync(string email, string password);
    }
}
