using System.ComponentModel.DataAnnotations.Schema;

namespace VOB.Data
{
    public class Cost
    {
        public Guid Id { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [ForeignKey("Unit")]
        public Guid UnitId { get; set; }
        public virtual Unit? Unit { get; set; } = null!;
    }
}
