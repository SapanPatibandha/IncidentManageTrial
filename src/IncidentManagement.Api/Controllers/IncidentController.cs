using Microsoft.AspNetCore.Mvc;
using IncidentManagement.Application.Interfaces;
using System.Threading.Tasks;

namespace IncidentManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentService _incidentService;

        public IncidentController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IncidentDto>> GetIncident(int id)
        {
            var incident = await _incidentService.GetIncidentAsync(id);
            if (incident == null)
            {
                return NotFound();
            }
            return Ok(incident);
        }

        [HttpPost]
        public async Task<ActionResult<IncidentDto>> CreateIncident([FromBody] IncidentDto incidentDto)
        {
            var createdIncident = await _incidentService.CreateIncidentAsync(incidentDto);
            return CreatedAtAction(nameof(GetIncident), new { id = createdIncident.Id }, createdIncident);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateIncident(int id, [FromBody] IncidentDto incidentDto)
        {
            if (id != incidentDto.Id)
            {
                return BadRequest();
            }

            _incidentService.UpdateIncidentAsync(id, incidentDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteIncident(int id)
        {
            _incidentService.DeleteIncidentAsync(id);
            return NoContent();
        }
    }
}