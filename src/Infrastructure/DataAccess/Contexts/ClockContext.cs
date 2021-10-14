using System;
using Domain.Entities;
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
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClockContext).Assembly);
        }
    }
}
