using System.ComponentModel.DataAnnotations.Schema;
using VOB.Models;

namespace VOB.Data
{
    public class Booking
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public double Quantity { get; set; }
        [Column(TypeName = "money")]
        public double TotalPrice { get; set; }

        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; } = null!;
        public virtual ApplicationUser? User { get; set; }

        [ForeignKey("ResidedCourt")]
        public Guid ResidedCourtId { get; set; }
        public virtual ResidedCourt? ResidedCourt { get; set; }

        [ForeignKey("Cost")]
        public Guid CostId { get; set; }
        public virtual Cost? Cost { get; set; }
    }
}
