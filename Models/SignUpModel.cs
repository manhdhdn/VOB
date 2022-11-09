using System.ComponentModel.DataAnnotations;

namespace VOB.Models
{
    public class SignUpModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Phone]
        public string PhoneNumber { get; set; } = null!;
        public string RoleId { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
