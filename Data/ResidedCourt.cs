using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VOB.Data
{
    public class ResidedCourt
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int Size { get; set; }
        public string Type { get; set; } = null!;

        [ForeignKey("Court")]
        public Guid CourtId { get; set; }
        public virtual Court? Court { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<Cost>? Costs { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<Photo>? Photos { get; set; }
    }
}
