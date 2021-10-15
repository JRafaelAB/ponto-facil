using Domain.Entities;
using Domain.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Contexts
{
    public sealed class ClockContext : DbContext
    {
        public ClockContext()
        {
            
        }

        public ClockContext(DbContextOptions<ClockContext> options) : base(options)
        {
            
        }
        
        public DbSet<User> Users { get; init; }
        
        public DbSet<Clock> Clocks { get; init; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ValidateNullArgument();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClockContext).Assembly);
        }
    }
}
