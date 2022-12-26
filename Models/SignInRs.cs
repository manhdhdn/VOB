namespace VOB.Models
{
    public class SignInRs
    {
        public ApplicationUser? User { get; set; }
        public string Token { get; set; } = null!;
    }
}
