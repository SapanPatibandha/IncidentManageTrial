using IncidentManagement.Domain.Entities;
using IncidentManagement.Domain.Interfaces;
using IncidentManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IncidentManagement.Infrastructure.Repositories
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly IncidentDbContext _context;

        public IncidentRepository(IncidentDbContext context)
        {
            _context = context;
        }

        public async Task<Incident> GetByIdAsync(int id)
        {
            return await _context.Incidents.FindAsync(id);
        }

        public async Task<IEnumerable<Incident>> GetAllAsync()
        {
            return await _context.Incidents.ToListAsync();
        }

        public async Task AddAsync(Incident incident)
        {
            await _context.Set<Incident>().AddAsync(incident);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Incident incident)
        {
            _context.Set<Incident>().Update(incident);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var incident = await GetByIdAsync(id);
            if (incident != null)
            {
                _context.Set<Incident>().Remove(incident);
                await _context.SaveChangesAsync();
            }
        }
    }
}