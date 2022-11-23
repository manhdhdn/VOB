using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VOB.Data
{
    public class Court
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;
        public string Location { get; set; } = null!;

        [ForeignKey("Policy")]
        public Guid PolicyId { get; set; }
        public virtual Policy? Policy { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<ResidedCourt>? ResidedCourts { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<Photo>? Photos { get; set; }
    }
}
