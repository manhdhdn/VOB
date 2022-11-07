using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace VOB.Repositories
{
    public interface IAccountRepo
    {
        Task<IdentityResult> SignUp(string email, string roleID, string password);
        Task<string?> SignIn([FromBody] string email, string password);
    }
}
