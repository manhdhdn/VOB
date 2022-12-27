namespace VOB.Models
{
    public class SignInRs
    {
        public User? User { get; set; }
        public string Token { get; set; } = null!;
    }
}
