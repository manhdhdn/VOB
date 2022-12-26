using System.ComponentModel.DataAnnotations;

namespace VOB.Models
{
    public class SignInModel
    {
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
