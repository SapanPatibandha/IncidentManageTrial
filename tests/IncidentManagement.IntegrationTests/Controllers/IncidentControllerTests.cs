using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace IncidentManagement.IntegrationTests.Controllers
{
    public class IncidentControllerTests : IClassFixture<WebApplicationFactory<IncidentManagement.Api.Program>>
    {
        private readonly HttpClient _client;

        public IncidentControllerTests(WebApplicationFactory<IncidentManagement.Api.Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetIncident_ReturnsOk_WhenIncidentExists()
        {
            var response = await _client.GetAsync("/api/incidents/1");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CreateIncident_ReturnsCreated_WhenIncidentIsValid()
        {
            var incident = new { Title = "Test Incident", Description = "Test Description" };
            var response = await _client.PostAsJsonAsync("/api/incidents", incident);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task UpdateIncident_ReturnsOk_WhenIncidentExists()
        {
            var incident = new { Title = "Updated Incident", Description = "Updated Description" };
            var response = await _client.PutAsJsonAsync("/api/incidents/1", incident);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task DeleteIncident_ReturnsNoContent_WhenIncidentExists()
        {
            var response = await _client.DeleteAsync("/api/incidents/1");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}