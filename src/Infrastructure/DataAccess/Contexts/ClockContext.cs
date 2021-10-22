using System.Data;
using Domain.Entities;
using Domain.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Contexts
{
    public class ClockContext : DbContext
    {
        
        private IDbConnection _connection;
        public IDbConnection Connection
        {
            get{
                if (_connection.State == ConnectionState.Open) return _connection;
                
                _connection.Open();

                while (_connection.State == ConnectionState.Connecting) {}

                return _connection;
            }
            private set => _connection = value;
        }
        
        public DbSet<User> Users { get; init; }
        
        public DbSet<Clock> Clocks { get; init; }
        
        public ClockContext()
        {
            
        }

        public ClockContext(DbContextOptions<ClockContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ValidateNullArgument();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClockContext).Assembly);
        }
    }
}
