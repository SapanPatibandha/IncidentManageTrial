using System.Threading.Tasks;
using IncidentManagement.Application.Interfaces;
using IncidentManagement.Domain.Entities;
using IncidentManagement.Domain.Interfaces;

namespace IncidentManagement.Application.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly IIncidentRepository _incidentRepository;

        public IncidentService(IIncidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }

        public async Task<IncidentDto?> GetIncidentAsync(int id)
        {
            var incident = await _incidentRepository.GetByIdAsync(id);
            if (incident == null)
            {
                return null;
            }
            return new IncidentDto
            {
                Id = incident.Id,
                Name = incident.Name,
                Description = incident.Description,
                Status = incident.Status,
                CreatedDate = incident.CreatedDate
            };
        }

        public async Task<IncidentDto> CreateIncidentAsync(IncidentDto incidentDto)
        {
            var incident = new Incident
            {
                Name = incidentDto.Name,
                Description = incidentDto.Description,
                Status = incidentDto.Status,
                CreatedDate = DateTime.UtcNow
            };
            await _incidentRepository.AddAsync(incident);
            return new IncidentDto
            {
                Id = incident.Id,
                Name = incident.Name,
                Description = incident.Description,
                Status = incident.Status,
                CreatedDate = incident.CreatedDate
            };
        }

        public async Task<IncidentDto?> UpdateIncidentAsync(int id, IncidentDto incidentDto)
        {
            var incident = await _incidentRepository.GetByIdAsync(id);
            if (incident != null)
            {
                incident.Name = incidentDto.Name;
                incident.Description = incidentDto.Description;
                incident.Status = incidentDto.Status;
                await _incidentRepository.UpdateAsync(incident);
                return new IncidentDto
                {
                    Id = incident.Id,
                    Name = incident.Name,
                    Description = incident.Description,
                    Status = incident.Status,
                    CreatedDate = incident.CreatedDate
                };
            }
            return null;
        }

        public async Task<bool> DeleteIncidentAsync(int id)
        {
            var incident = await _incidentRepository.GetByIdAsync(id);
            if (incident != null)
            {
                await _incidentRepository.DeleteAsync(incident.Id);
                return true;
            }
            return false;
        }

        public async Task<IncidentDto?> DeleteIncidentByIdAsync(int id)
        {
            var incident = await _incidentRepository.GetByIdAsync(id);
            return incident != null ? new IncidentDto
            {
                Id = incident.Id,
                Name = incident.Name,
                Description = incident.Description,
                Status = incident.Status,
                CreatedDate = incident.CreatedDate
            } : null;
        }


        public async Task UpdateIncidentAsync(IncidentDto incidentDto)
        {
            var incident = await _incidentRepository.GetByIdAsync(incidentDto.Id);
            if (incident != null)
            {
                incident.Name = incidentDto.Name;
                incident.Description = incidentDto.Description;
                incident.Status = incidentDto.Status;
                await _incidentRepository.UpdateAsync(incident);
            }
        }

        public async Task DeleteIncident(int id)
        {
            var incident = await _incidentRepository.GetByIdAsync(id);
            if (incident != null)
            {
                await _incidentRepository.DeleteAsync(incident.Id);
            }
        }
    }
}