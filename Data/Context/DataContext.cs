using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VOB.Models;
using VOB.Data;

namespace VOB.Data.Context
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options)
        {
        }

        public virtual DbSet<Court> Courts { get; set; } = null!;
        public virtual DbSet<Policy> Policy { get; set; } = null!;
        public virtual DbSet<ResidedCourt> ResidedCourt { get; set; } = null!;
    }
}
