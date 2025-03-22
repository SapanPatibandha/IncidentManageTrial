namespace IncidentManagement.Application.Interfaces
{
    public interface IIncidentService
    {
        Task<IncidentDto> GetIncidentAsync(int id);
        Task<IncidentDto> CreateIncidentAsync(IncidentDto incidentDto);
        Task<IncidentDto> UpdateIncidentAsync(int id, IncidentDto incidentDto);
        Task<bool> DeleteIncidentAsync(int id);
    }
}