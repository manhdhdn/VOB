using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VOB.Data
{
    public class Photo
    {
        [Key]
        public Guid Id { get; set; }
        public string Url { get; set; } = null!;

        [ForeignKey("Court")]
        public Guid? CourtId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual Court? Court { get; set; }

        [ForeignKey("ResidedCourt")]
        public Guid? ResidedCourtId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ResidedCourt? ResidedCourt { get; set; }
    }
}
