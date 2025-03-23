using IncidentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

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

            // Seed data
            modelBuilder.Entity<Incident>().HasData(
                new Incident
                {
                    Id = 1,
                    Name = "Example Incident",
                    Description = "This is an example incident.",
                    CreatedBy = "System",
                    CreatedDate = DateTime.UtcNow,
                    ModifiedBy = "System",
                    ModifiedDate = DateTime.UtcNow,
                    Status = Domain.Enums.IncidentStatus.Created,
                    Priority = 1
                }
            );

            modelBuilder.Entity<Discussion>().HasData(
                new Discussion
                {
                    Id = 1,
                    IncidentId = 1,
                    Comment = "This is an example comment.",
                    CreatedBy = "System",
                    CreatedDate = DateTime.UtcNow
                }
            );
        }
    }
}