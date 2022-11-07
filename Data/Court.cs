using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VOB.Data
{
    public class Court
    {
        [Key]
        public string Id { get; set; } = null!;
        [Column("Name")]
        public string CourtName { get; set; } = null!;
    }
}
