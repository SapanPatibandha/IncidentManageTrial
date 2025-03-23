using IncidentManagement.Domain.Entities;

namespace IncidentManagement.Domain.Interfaces
{
    public interface IIncidentRepository
    {
        Task<Incident> GetByIdAsync(int id);
        Task<IEnumerable<Incident>> GetAllAsync();
        Task AddAsync(Incident incident);
        Task UpdateAsync(Incident incident);
        Task DeleteAsync(int id);
    }
}