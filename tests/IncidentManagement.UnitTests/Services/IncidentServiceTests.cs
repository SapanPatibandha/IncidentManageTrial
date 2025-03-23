using Xunit;
using Moq;
using IncidentManagement.Application.Interfaces;
using IncidentManagement.Application.Services;
using IncidentManagement.Domain.Interfaces;

namespace IncidentManagement.UnitTests.Services
{
    public class IncidentServiceTests
    {
        private readonly Mock<IIncidentRepository> _mockRepository;
        private readonly IIncidentService _incidentService;

        public IncidentServiceTests()
        {
            _mockRepository = new Mock<IIncidentRepository>();
            _incidentService = new IncidentService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetIncident_ShouldReturnIncident_WhenIncidentExists()
        {
            // Arrange
            var incidentId = 1;
            var expectedIncident = new Incident { Id = incidentId, Title = "Test Incident" };
            _mockRepository.Setup(repo => repo.GetByIdAsync(incidentId)).ReturnsAsync(expectedIncident);

            // Act
            var result = await _incidentService.GetIncidentAsync(incidentId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedIncident.Title, result.Title);
        }

        [Fact]
        public async Task CreateIncident_ShouldAddIncident_WhenValid()
        {
            // Arrange
            var newIncidentDto = new IncidentDto { Title = "New Incident", Description = "Incident Description" };
            var newIncident = new Incident { Title = newIncidentDto.Title, Description = newIncidentDto.Description };

            // Act
            await _incidentService.CreateIncidentAsync(newIncidentDto);

            _mockRepository.Verify(repo => repo.AddAsync(It.Is<Incident>(i => i.Title == newIncidentDto.Title && i.Description == newIncidentDto.Description)), Times.Once);
            _mockRepository.Verify(repo => repo.AddAsync(newIncident), Times.Once);
        }

        [Fact]
        public async Task UpdateIncident_ShouldUpdateIncident_WhenValid()
        {
            // Arrange
            var existingIncident = new Incident { Id = 1, Title = "Old Title" };
            var updatedIncident = new Incident { Id = 1, Title = "Updated Title" };
            _mockRepository.Setup(repo => repo.GetByIdAsync(existingIncident.Id)).ReturnsAsync(existingIncident);

            // Act
            var updatedIncidentDto = new IncidentDto { Title = updatedIncident.Title };
            await _incidentService.UpdateIncidentAsync(updatedIncident.Id, updatedIncidentDto);

            // Assert
            _mockRepository.Verify(repo => repo.UpdateAsync(updatedIncident), Times.Once);
        }

        [Fact]
        public async Task DeleteIncident_ShouldRemoveIncident_WhenExists()
        {
            // Arrange
            var incidentId = 1;
            _mockRepository.Setup(repo => repo.GetByIdAsync(incidentId)).ReturnsAsync(new Incident { Id = incidentId });

            // Act
            await _incidentService.DeleteIncidentAsync(incidentId);

            // Assert
            _mockRepository.Verify(repo => repo.DeleteAsync(incidentId), Times.Once);
        }
    }
}