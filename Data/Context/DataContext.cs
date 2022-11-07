using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VOB.Data.Context
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options)
        {
        }

        public virtual DbSet<Court> Courts { get; set; } = null!;
    }
}
