using System.ComponentModel.DataAnnotations;

namespace VOB.Data
{
    public class Policy
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Describle { get; set; } = null!;
    }
}
