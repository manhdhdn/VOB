using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VOB.Data
{
    public class Policy
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<Court>? Courts { get; set; }
    }
}
