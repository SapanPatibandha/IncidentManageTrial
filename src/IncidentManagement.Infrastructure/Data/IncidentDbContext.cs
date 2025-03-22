using IncidentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IncidentManagement.Infrastructure.Data
{
    public class IncidentDbContext : DbContext
    {
        public IncidentDbContext(DbContextOptions<IncidentDbContext> options) : base(options)
        {
        }

        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Discussion> Discussions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incident>().ToTable("Incidents");
            modelBuilder.Entity<Discussion>().ToTable("Discussions");
            // Additional configuration can be added here
        }
    }
}